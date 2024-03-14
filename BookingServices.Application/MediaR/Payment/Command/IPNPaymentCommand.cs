using BookingServices.External.Model.VNPay.Request;
using BookingServices.External.Model.VNPay.Response;

namespace BookingServices.Application.MediaR.Payment.Command;

public class IPNPaymentCommand : IRequest<IPNResponse>
{
    public IPNRequest IPNRequest { get; set; }
}
