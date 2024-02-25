using BookingServices.Entities.Enum;

namespace BookingServices.Application.MediaR.Booking.Command.Update.Status;

public class BookingUpdateStatusCommand : IRequest<bool>
{
    public List<Guid> BookingIds { get; set; }
    public EBookingStatus BookingStatus { get; set; }
}
