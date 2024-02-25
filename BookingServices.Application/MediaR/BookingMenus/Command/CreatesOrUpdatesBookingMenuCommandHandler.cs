using AutoMapper;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;

namespace BookingServices.Application.MediaR.BookingMenus.Command;

public class CreatesOrUpdatesBookingMenuCommandHandler : IRequestHandler<CreatesOrUpdatesBookingMenuCommand, bool>
{
    private readonly BookingDbContext _bookingDbContext;
    private readonly IMapper _mapper;
    public CreatesOrUpdatesBookingMenuCommandHandler(BookingDbContext bookingDbContext, IMapper mapper)
    {
        _bookingDbContext = bookingDbContext;
        _mapper = mapper;
    }

    public Task<bool> Handle(CreatesOrUpdatesBookingMenuCommand request, CancellationToken cancellationToken)
    {
        //get booking by id if null throw exception
        var booking = _bookingDbContext.Bookings.FirstOrDefault(x => x.Id == request.BookingId);
        if (booking == null)
        {
            throw new ClientException("Booking not found");
        }

        //get all menu by booking id
        var bookingMenus = _bookingDbContext.BookingMenu.Where(x => x.BookingId == request.BookingId).ToList();
        //check each request menu
        foreach (var item in request.MenuRequests.Where(x => !x.IsRemove))
        {
            //if exist in booking menu update
            var bookingMenu = bookingMenus.FirstOrDefault(x => x.Id == item.Id);
            if (bookingMenu != null)
            {
                bookingMenu.Quantity = item.Quantity;
                bookingMenu.SpecialRequest = item.SpecialRequest;
                _bookingDbContext.Update(bookingMenu);
            }
            else
            {
                //if not exist add
                var newBookingMenu = new BookingMenu
                {
                    BookingId = request.BookingId,
                    MenuId = item.MenuId,
                    Quantity = item.Quantity,
                    SpecialRequest = item.SpecialRequest,
                    Price = item.Price
                };
                _bookingDbContext.Add(newBookingMenu);
            }
        }

        //remove menu
        foreach (var item in request.MenuRequests.Where(x => x.IsRemove))
        {
            var bookingMenu = bookingMenus.FirstOrDefault(x => x.Id == item.Id);
            if (bookingMenu != null)
            {
                _bookingDbContext.Remove(bookingMenu);
            }
        }

        _bookingDbContext.SaveChanges();
        return Task.FromResult(true);
    }
}
