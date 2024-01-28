using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Enum;
using BookingServices.Model.BookingMenuModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.BookingMenu;

public class BookingMenuServices : IBookingMenuServices
{
    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;

    public BookingMenuServices(BookingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddBookingMenuAsync(AddBookingMenuRequest request)
    {
        var booking = await _context.Bookings.FindAsync(request.BookingId);
        if (booking == null) throw new Exception("Booking not found");
        //check booking status
        if (booking.BookingStatusId <= EBookingStatus.Confirm) throw new Exception("Booking status is not valid");


        //check menu exist
        var menu = await _context.RestaurantMenu.FindAsync(request.MenuId);
        if (menu == null) throw new Exception("Menu not found");

        //check booking menu exist
        var checkExist = _context.BookingMenu.FirstOrDefault(x => x.BookingId == request.BookingId && x.MenuId == request.MenuId);
        if (checkExist != null)
        {
            //update
            checkExist.Quantity += request.Quantity;
            _context.Update(checkExist);
            await _context.SaveChangesAsync();
        }

        //mapper
        _context.Add(_mapper.Map<BookingMenuServices>(request));
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookingMenuAsync(Guid id)
    {
        //check exist if null throw exception
        var checkExist = _context.BookingMenu.FirstOrDefault(x => x.Id == id);
        if (checkExist == null) throw new Exception("Booking menu not found");

        //check bookingstatus
        var booking = await _context.Bookings.FindAsync(checkExist.BookingId);
        if (booking == null) throw new Exception("Booking not found");
        if (booking.BookingStatusId <= EBookingStatus.Confirm) throw new Exception("Booking status is not valid");

        //remove
        _context.Remove(checkExist);
        await _context.SaveChangesAsync();
    }

    public async Task<ApiPaged<BookingMenuDTO>> GetAllBookingMenuAsync(GetAllBookingMenuRequest request)
    {
        return new ApiPaged<BookingMenuDTO>
        {
            Items = _mapper.Map<IEnumerable<BookingMenuDTO>>(await _context.BookingMenu
                                .WhereIf(request.BookingId != null,x => x.BookingId == request.BookingId)
                                .WhereIf(request.RestaurantMenuId != null, x=> x.MenuId == request.RestaurantMenuId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = await _context.BookingMenu.Where(x => x.BookingId == request.BookingId).CountAsync()
        };
    }

    public async Task<BookingMenuDTO> GetBookingMenuByIdAsync(Guid id) => _mapper.Map<BookingMenuDTO>(await _context.BookingMenu.FirstOrDefaultAsync(x => x.Id == id));

    public async Task UpdateBookingMenuAsync(UpdateBookingMenuRequest request)
    {
        //check exist if null throw exception
        var checkExist = _context.BookingMenu.FirstOrDefault(x => x.Id == request.Id);
        if (checkExist == null) throw new Exception("Booking menu not found");

        //check bookingstatus
        var booking = await _context.Bookings.FindAsync(checkExist.BookingId);
        if (booking == null) throw new Exception("Booking not found");
        if (booking.BookingStatusId <= EBookingStatus.Confirm) throw new Exception("Booking status is not valid");

        //mapper
        _mapper.Map(request, checkExist);
        _context.Update(checkExist);
        await _context.SaveChangesAsync();
    }
}
