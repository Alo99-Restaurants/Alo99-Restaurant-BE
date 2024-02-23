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
        var tables = _bookingDbContext.Tables.Include(x=> x.Bookings.Where(x=> x.BookingDate.Date == booking.BookingDate)).Where(x => booking.TableIds.Contains(x.Id)).ToList();
        if (tables == null) throw new ClientException("Tables not found");
        //check count table
        if (tables.Count != booking.TableIds.Count) throw new ClientException("One of tables not exist");

        //check table valid
        //var validTables = _mapper.Map<List<TableDTO>>(tables);
        //foreach (var item in validTables)
        //{
            //if (item.IsAvailable() == false) throw new ClientException("Table not available");
            //number of people must > item.Capacity
            //if (item.Capacity >= booking.NumberOfPeople && booking.TableIds.Count > 1) throw new ClientException("Please book one table for this booking");
        //}
        ////if (validTables.Sum(x=> x.Capacity) <= booking.NumberOfPeople) throw new ClientException("Booking capacity is greater than table capacity");

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
        var data = await _bookingDbContext.Bookings.Include(x=> x.Tables).ThenInclude(x=> x.RestaurantFloor)
                    .WhereIf(request.RestaurantId != null, x => x.Tables.Where(x=> x.RestaurantFloor.RestaurantId == request.RestaurantId).Any())
                    .WhereIf(request.UserId != null, x => x.CreatedBy == request.UserId)
                    .WhereIf(request.CustomerId != null, x => x.CustomerId == request.CustomerId)
                    .WhereIf(request.TableId != null, x => x.Tables.Where(x=> x.Id == request.TableId).Any())
                    .WhereIf(request.BookingDate != null, x => x.BookingDate.Date == (request.BookingDate??DateTime.MinValue))
                    .WhereIf(request.BookingStatus != null, x => x.BookingStatusId == request.BookingStatus)
                    .Skip(request.SkipRows).Take(request.TotalRows).ToListAsync();
        //if (data == null) throw new ClientException("Booking not found");
        return new ApiPaged<BookingDTO>
        {
            Items =_mapper.Map<IEnumerable<BookingDTO>>(data),
            TotalRecords = await _bookingDbContext.Bookings.Include(x => x.Tables).ThenInclude(x=> x.RestaurantFloor)
                    .WhereIf(request.RestaurantId != null, x => x.Tables.Where(x => x.RestaurantFloor.RestaurantId == request.RestaurantId).Any())
                    .WhereIf(request.UserId != null, x => x.CreatedBy == request.UserId)
                    .WhereIf(request.CustomerId != null, x => x.CustomerId == request.CustomerId)
                    .WhereIf(request.TableId != null, x => x.Tables.Where(x => x.Id == request.TableId).Any())
                    .WhereIf(request.BookingDate != null, x => x.BookingDate.Date == (request.BookingDate ?? DateTime.MinValue))
                    .WhereIf(request.BookingStatus != null, x => x.BookingStatusId == request.BookingStatus)
                    .CountAsync()
        };
    }

    public async Task<BookingDTO?> GetBookingByIdAsync(Guid id)
    {
        return _mapper.Map<BookingDTO>(await _bookingDbContext.Bookings.Include(x => x.Tables).Include(x => x.Customer).FirstOrDefaultAsync(x=> x.Id == id));
    }

    public Task UpdateBookingAsync(UpdateBookingRequest booking)
    {
        //check exist
        var bookingEntity = _bookingDbContext.Bookings.Include(x=> x.Tables).FirstOrDefault(x=> x.Id == booking.Id);
        if (bookingEntity == null) throw new ClientException("Booking not found");

        //check table
        var tables = _bookingDbContext.Tables.Where(x => booking.TableIds.Contains(x.Id))
                                                               .Include(x => x.Bookings.Where(x => x.BookingDate.Date == booking.BookingDate)).ToList();
        if (tables == null) throw new ClientException("Table not found");
        //check count table
        if (tables.Count != booking.TableIds.Count) throw new ClientException("One of tables not exist");

        //foreach (var item in tables)
        //{
        //    //if (item.Capacity >= booking.NumberOfPeople && booking.TableIds.Count > 1) throw new ClientException("Please book one table for this booking");
        //    if (bookingEntity.Tables.Contains(item)) continue;
        //    var dto = _mapper.Map<TableDTO>(item);
        //    if (dto?.IsAvailable() == false) throw new ClientException("Table not available");
        //}

        //if (tables.Sum(x => x.Capacity) <= booking.NumberOfPeople) throw new ClientException("Booking capacity is greater than table capacity");
        
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
