using AutoMapper;
using BookingServices.Entities.Contexts;

namespace BookingServices.Application.MediaR.Booking.Command.Remove.All;

public class BookingRemoveAllCommandHandler : IRequestHandler<BookingRemoveAllCommand, bool>
{
    private readonly BookingDbContext _bookingDbContext;
    private readonly IMapper _mapper;
    public BookingRemoveAllCommandHandler(BookingDbContext bookingDbContext, IMapper mapper)
    {
        _bookingDbContext = bookingDbContext;
        _mapper = mapper;
    }

    public Task<bool> Handle(BookingRemoveAllCommand request, CancellationToken cancellationToken)
    {
        var getAllBooking = _bookingDbContext.Bookings.ToList();
        _bookingDbContext.RemoveRange(getAllBooking, cancellationToken);
        _bookingDbContext.SaveChanges();
        return Task.FromResult(true);
    }
}
