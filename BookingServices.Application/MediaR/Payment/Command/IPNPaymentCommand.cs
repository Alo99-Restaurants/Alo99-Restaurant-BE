using BookingServices.External.Model.VNPay.Response;

namespace BookingServices.Application.MediaR.Payment.Command;

public class IPNPaymentCommand : IRequest<bool>
{
    public IPNResponse IPNResponse { get; set; }
}
