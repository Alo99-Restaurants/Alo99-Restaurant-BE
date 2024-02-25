namespace BookingServices.Application.MediaR.Payment.Query.Url;

public class GetPaymentUrlByBookingCommand : IRequest<string>
{
    public Guid BookingId { get; set; }
    public string ReturnUrl { get; set; }
}
