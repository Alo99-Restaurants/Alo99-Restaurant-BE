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
        if (user == null) throw new Exception("User not found");
        booking.CustomerId = user.CustomerId;

        //check table valid
        var validTable = _mapper.Map<TableDTO>(_bookingDbContext.Tables.Where(x => x.Id == booking.TableId).Include(x => x.BookingTables).ThenInclude(x=> x.Booking.BookingDate.Date == booking.BookingDate.Date).FirstOrDefault()).IsAvailable();
        if(validTable == false) throw new Exception("Table not available");

        var addBooking = _mapper.Map<Bookings>(booking);
        _bookingDbContext.Add(addBooking);
        await _bookingDbContext.SaveChangesAsync();
    }

    public async Task DeleteBookingAsync(Guid id)
    {
        //check exist booking
        var booking = _bookingDbContext.Bookings.Find(id);
        if (booking == null) throw new Exception("Booking not found");

        //delete booking
        _bookingDbContext.Remove(booking);
        await _bookingDbContext.SaveChangesAsync();
    }

    public async Task<ApiPaged<BookingDTO>> GetAllBookingAsync(GetAllBookingRequest request)
    {
        var data = await _bookingDbContext.Bookings.Include(x=> x.BookingTables).ThenInclude(x=> x.TableId)
                    .WhereIf(request.UserId != null, x => x.CreatedBy == request.UserId)
                    .WhereIf(request.CustomerId != null, x => x.CustomerId == request.CustomerId)
                    .WhereIf(request.TableId != null, x => x.BookingTables.Where(x=> x.TableId == request.TableId).Any())
                    .Skip(request.SkipRows).Take(request.TotalRows).ToListAsync();
        if (data == null) throw new ClientException("Booking not found");
        return new ApiPaged<BookingDTO>
        {
            Items =_mapper.Map<IEnumerable<BookingDTO>>(data),
            TotalRecords = await _bookingDbContext.Bookings.Include(x => x.BookingTables).ThenInclude(x => x.TableId)
                    .WhereIf(request.UserId != null, x => x.CreatedBy == request.UserId)
                    .WhereIf(request.CustomerId != null, x => x.CustomerId == request.CustomerId)
                    .WhereIf(request.TableId != null, x => x.BookingTables.Where(x => x.TableId == request.TableId).Any()).CountAsync()
        };
    }

    public async Task<BookingDTO> GetBookingByIdAsync(Guid id)
    {
        return _mapper.Map<BookingDTO>(await _bookingDbContext.Bookings.Include(x => x.BookingTables).ThenInclude(x=> x.Table).Include(x => x.Customer).FirstOrDefaultAsync(x=> x.Id == id));
    }

    public Task UpdateBookingAsync(UpdateBookingRequest booking)
    {
        //check exist
        var bookingEntity = _bookingDbContext.Bookings.Find(booking.Id);
        if (bookingEntity == null) throw new Exception("Booking not found");

        if(bookingEntity.BookingDate.Date != booking.BookingDate.Date)
        {
            //check table valid
            var validTable = _mapper.Map<TableDTO>(_bookingDbContext.Tables.Where(x => x.Id == booking.TableId)
                                                               .Include(x => x.BookingTables.Where(x => x.Booking.BookingDate.Date == booking.BookingDate)).FirstOrDefault()).IsAvailable();
            if (validTable == false) throw new Exception("Table not available");
        }

        //map booking
        _mapper.Map(booking, bookingEntity);

        //update booking
        _bookingDbContext.Update(bookingEntity);
        //save changes
        _bookingDbContext.SaveChanges();
        return Task.CompletedTask;
    }
}
