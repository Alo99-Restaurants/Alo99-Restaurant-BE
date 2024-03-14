using BookingServices.Application.Services.Booking;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Entities.Enum;
using BookingServices.External.Interfaces;
using BookingServices.External.Model.VNPay.Response;
using Hangfire;
using Microsoft.Extensions.Logging;

namespace BookingServices.Application.MediaR.Payment.Command;

public class IPNPaymentCommandHandler : IRequestHandler<IPNPaymentCommand, IPNResponse>
{
    private readonly BookingDbContext _context;
    private readonly IVnPayServices _vnPayServices;
    private readonly ILogger _logger;

    public IPNPaymentCommandHandler(BookingDbContext context, IVnPayServices vnPayServices, ILogger<IPNPaymentCommandHandler> logger)
    {
        _context = context;
        _vnPayServices = vnPayServices;
        _logger = logger;
    }

    public async Task<IPNResponse> Handle(IPNPaymentCommand request, CancellationToken cancellationToken)
    {
        var result = new IPNResponse { RspCode = "99", Message = "Unknow error" };
        try
        {
            var valid = _vnPayServices.ValidateSignature(request.IPNRequest);
            if (valid)
            {
                //create tracsaction
                var transaction = new Transaction
                {
                    Id = Guid.NewGuid(),
                    Amount = double.Parse(request.IPNRequest.vnp_Amount),
                    BankCode = request.IPNRequest.vnp_BankCode,
                    BankTranNo = request.IPNRequest.vnp_BankTranNo,
                    CardType = request.IPNRequest.vnp_CardType,
                    PayDate = request.IPNRequest.vnp_PayDate,
                    OrderInfo = request.IPNRequest.vnp_OrderInfo,
                    ResponseCode = request.IPNRequest.vnp_ResponseCode,
                    TransactionNo = long.Parse(request.IPNRequest.vnp_TransactionNo),
                    TransactionStatus = request.IPNRequest.vnp_TransactionStatus,
                    TxnRef = request.IPNRequest.vnp_TxnRef,
                    SecureHashType = request.IPNRequest.vnp_SecureHashType,
                    SecureHash = request.IPNRequest.vnp_SecureHash
                };
                _context.Add(transaction);
                var bookingId = Guid.Parse(request.IPNRequest.vnp_TxnRef.Substring(0, 36));
                //get bookingById and update status
                var booking = _context.Bookings.FirstOrDefault(x => x.Id == bookingId);

                if (booking != null)
                {
                    var paymentExist = _context.Payments.Where(x => x.BookingId == bookingId).Any();
                    if (request.IPNRequest.vnp_ResponseCode == "00" && request.IPNRequest.vnp_TransactionStatus == "00" && !paymentExist)
                    {   
                        booking.BookingStatusId = EBookingStatus.Completed;
                        _context.Update(booking);

                        //create payment
                        var payment = new Payments
                        {
                            Id = Guid.NewGuid(),
                            Amount = double.Parse(request.IPNRequest.vnp_Amount),
                            BookingId = bookingId,
                            TransactionId = transaction.Id,
                            Transaction = transaction
                        };
                        _context.Add(payment);
                        result = new IPNResponse
                        {
                            RspCode = "00",
                            Message = "Confirm Success"
                        };
                    }
                    else
                    {
                        result = new IPNResponse
                        {
                            RspCode = "02",
                            Message = "Order already confirmed"
                        };
                    }
                }
                else
                {
                    result = new IPNResponse
                    {
                        RspCode = "01",
                        Message = "Order not found"
                    };
                }
                await _context.SaveChangesAsync();
                if (result.RspCode.Equals("00") && booking != null) BackgroundJob.Enqueue<IBookingServices>(x => x.BuildEmailAsync(booking.Id));
            }
            else
            {
                result = new IPNResponse
                {
                    Message = "Invalid signature",
                    RspCode = "97"
                };
            }
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error when handle IPNPaymentCommand");
            return result;
        }
    }
}
