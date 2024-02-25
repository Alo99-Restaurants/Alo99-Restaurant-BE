using BookingServices.Entities.Contexts;
using BookingServices.External.Interfaces;
using BookingServices.External.Model.VNPay;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.MediaR.Payment.Query.Url;

public class GetPaymentUrlByBookingCommandHandler : IRequestHandler<GetPaymentUrlByBookingCommand, string>
{
    private readonly BookingDbContext _context;
    private readonly IVnPayServices _vnPayService;

    public GetPaymentUrlByBookingCommandHandler(BookingDbContext context, IVnPayServices vnPayService)
    {
        _context = context;
        _vnPayService = vnPayService;
    }

    public async Task<string> Handle(GetPaymentUrlByBookingCommand request, CancellationToken cancellationToken)
    {
        //get booking by id check null
        var booking =await _context.Bookings.FirstOrDefaultAsync(x => x.Id == request.BookingId);
        if (booking == null) throw new ClientException("Booking not found");

        //get total price
        var totalPrice = _context.BookingMenu.Where(x => x.BookingId == request.BookingId).Sum(x => x.Price * x.Quantity);

        //get payment url
        var paymentUrl = _vnPayService.GetPaymentUrl(new OrderInfo
        {
            Amount = (long)totalPrice,
            CreatedDate = DateTime.Now,
            OrderId = booking.Id,
        }, request.ReturnUrl);

        return paymentUrl;
    }
}
