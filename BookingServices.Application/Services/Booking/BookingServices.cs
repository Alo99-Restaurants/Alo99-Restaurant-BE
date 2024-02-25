using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Identity;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.BookingModels;
using BookingServices.Model.TableModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;

namespace BookingServices.Application.Services.Booking;

public class BookingServices : IBookingServices
{
    private readonly BookingDbContext _bookingDbContext;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public BookingServices(BookingDbContext bookingDbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
    {
        _bookingDbContext = bookingDbContext;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task AddBookingAsync(AddBookingRequest booking)
    {
        //get user id
        var userId = ClaimsPrincipalExtension.GetUserId(_httpContextAccessor.HttpContext.User);
        // get user by user id and check exist
        var user = await _bookingDbContext.Users.FirstOrDefaultAsync(x => x.Id == userId);
        if (user == null) throw new ClientException("User not found");
        
        //get table by table id and check exist
        var tables = _bookingDbContext.Tables.Where(x => booking.TableIds.Contains(x.Id)).Include(x=> x.RestaurantFloor).Include(x=> x.Bookings.Where(x=> x.BookingDate.Date == booking.BookingDate)).ToList();
        if (tables == null) throw new ClientException("Tables not found");
        //check count table
        if (tables.Count != booking.TableIds.Count) throw new ClientException("One of tables not exist");
        
        var restaurantIds = tables.GroupBy(x=> x.RestaurantFloor.RestaurantId).ToList();
        if(restaurantIds.Exists(x=> x.Key != booking.RestaurantId)) throw new ClientException("Table not belong to restaurant");

        var addBooking = _mapper.Map<Bookings>(booking)??throw new Exception("Internal Error");
        addBooking.CustomerId = user.CustomerId;
        addBooking.Tables = tables;

        _bookingDbContext.Add(addBooking);
        await _bookingDbContext.SaveChangesAsync();
    }

    public async Task DeleteBookingAsync(Guid id)
    {
        //check exist booking
        var booking = _bookingDbContext.Bookings.Find(id);
        if (booking == null) throw new ClientException("Booking not found");

        //delete booking
        _bookingDbContext.Remove(booking);
        await _bookingDbContext.SaveChangesAsync();
    }

    public async Task<ApiPaged<BookingDTO>> GetAllBookingAsync(GetAllBookingRequest request)
    {
        var data = await _bookingDbContext.Bookings.Include(x=> x.Tables)
                    .WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId)
                    .WhereIf(request.UserId != null, x => x.CreatedBy == request.UserId)
                    .WhereIf(request.CustomerId != null, x => x.CustomerId == request.CustomerId)
                    .WhereIf(request.TableId != null, x => x.Tables.Where(x=> x.Id == request.TableId).Any())
                    .WhereIf(request.BookingDate != null, x => x.BookingDate.Date == (request.BookingDate??DateTime.MinValue))
                    .WhereIf(request.BookingStatus != null, x => request.BookingStatus.Contains(x.BookingStatusId))
                    .Skip(request.SkipRows).Take(request.TotalRows).ToListAsync();
        return new ApiPaged<BookingDTO>
        {
            Items =_mapper.Map<IEnumerable<BookingDTO>>(data),
            TotalRecords = await _bookingDbContext.Bookings.Include(x=> x.Restaurant).Include(x => x.Tables)
                    .WhereIf(request.RestaurantId != null, x => x.RestaurantId == request.RestaurantId)
                    .WhereIf(request.UserId != null, x => x.CreatedBy == request.UserId)
                    .WhereIf(request.CustomerId != null, x => x.CustomerId == request.CustomerId)
                    .WhereIf(request.TableId != null, x => x.Tables.Where(x => x.Id == request.TableId).Any())
                    .WhereIf(request.BookingDate != null, x => x.BookingDate.Date == (request.BookingDate ?? DateTime.MinValue))
                    .WhereIf(request.BookingStatus != null, x => request.BookingStatus.Contains(x.BookingStatusId))
                    .CountAsync()
        };
    }

    public async Task<BookingDTO?> GetBookingByIdAsync(Guid id)
    {
        return _mapper.Map<BookingDTO>(await _bookingDbContext.Bookings.Include(x => x.Tables).Include(x => x.Customer).Include(x=> x.Restaurant).FirstOrDefaultAsync(x=> x.Id == id));
    }

    public Task UpdateBookingAsync(UpdateBookingRequest booking)
    {
        //check exist
        var bookingEntity = _bookingDbContext.Bookings.Include(x=> x.Tables).FirstOrDefault(x=> x.Id == booking.Id);
        if (bookingEntity == null) throw new ClientException("Booking not found");

        //check table
        var tables = _bookingDbContext.Tables.Where(x => booking.TableIds.Contains(x.Id)).Include(x => x.RestaurantFloor)
                                                               .Include(x => x.Bookings.Where(x => x.BookingDate.Date == booking.BookingDate)).ToList();
        if (tables == null) throw new ClientException("Table not found");
        //check count table
        if (tables.Count != booking.TableIds.Count) throw new ClientException("One of tables not exist");

        var restaurantIds = tables.GroupBy(x => x.RestaurantFloor.RestaurantId).ToList();
        if (restaurantIds.Exists(x => x.Key != booking.RestaurantId)) throw new ClientException("Table not belong to restaurant");
        
        //map booking
        _mapper.Map(booking, bookingEntity);
        //update booking
        bookingEntity.Tables = tables;
        _bookingDbContext.Update(bookingEntity);
        //save changes
        _bookingDbContext.SaveChanges();
        return Task.CompletedTask;
    }
}
