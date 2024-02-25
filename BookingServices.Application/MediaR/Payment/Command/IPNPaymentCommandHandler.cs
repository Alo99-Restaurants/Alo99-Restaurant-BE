using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Entities.Enum;
using BookingServices.External.Interfaces;

namespace BookingServices.Application.MediaR.Payment.Command;

public class IPNPaymentCommandHandler : IRequestHandler<IPNPaymentCommand, bool>
{
    private readonly BookingDbContext _context;
    private readonly IVnPayServices _vnPayServices;

    public IPNPaymentCommandHandler(BookingDbContext context, IVnPayServices vnPayServices)
    {
        _context = context;
        _vnPayServices = vnPayServices;
    }

    public async Task<bool> Handle(IPNPaymentCommand request, CancellationToken cancellationToken)
    {
        var result = false;
        var valid = _vnPayServices.ValidateSignature(request.IPNResponse);
        if (valid)
        {
            //create tracsaction
            var transaction = new Transaction
            {
                Id = Guid.NewGuid(),
                Amount = double.Parse(request.IPNResponse.vnp_Amount),
                BankCode = request.IPNResponse.vnp_BankCode,
                BankTranNo = request.IPNResponse.vnp_BankTranNo,
                CardType = request.IPNResponse.vnp_CardType,
                PayDate = request.IPNResponse.vnp_PayDate,
                OrderInfo = request.IPNResponse.vnp_OrderInfo,
                ResponseCode = request.IPNResponse.vnp_ResponseCode,
                TransactionNo = long.Parse(request.IPNResponse.vnp_TransactionNo),
                TransactionStatus = request.IPNResponse.vnp_TransactionStatus,
                TxnRef = request.IPNResponse.vnp_TxnRef,
                SecureHashType = request.IPNResponse.vnp_SecureHashType,
                SecureHash = request.IPNResponse.vnp_SecureHash
            };
            _context.Add(transaction);

            if (request.IPNResponse.vnp_ResponseCode == "00" && request.IPNResponse.vnp_TransactionStatus == "00")
            {
                var bookingId = Guid.Parse(request.IPNResponse.vnp_TxnRef);
                //get bookingById and update status
                var booking = _context.Bookings.FirstOrDefault(x => x.Id == bookingId);
                if (booking != null)
                {
                    booking.BookingStatusId = EBookingStatus.Completed;
                    _context.Update(booking);

                    //create payment
                    var payment = new Payments
                    {
                        Id = Guid.NewGuid(),
                        Amount = double.Parse(request.IPNResponse.vnp_Amount),
                        BookingId = bookingId,
                        TransactionId = transaction.Id,
                        Transaction = transaction
                    };
                    _context.Add(payment);
                    result = true;
                }
            }
            await _context.SaveChangesAsync();
        }
        return result;
    }
}
