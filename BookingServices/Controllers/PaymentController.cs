using BookingServices.Application.MediaR.Payment.Command;
using BookingServices.Application.MediaR.Payment.Query.Url;
using BookingServices.Core;
using BookingServices.External.Model.VNPay.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : MyControllerBase
{
    private readonly ILogger<PaymentController> _logger;
    private readonly IMediator _mediator;

    public PaymentController(ILogger<PaymentController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    //api tạo thanh toán
    [HttpPost("create-payment")]
    public IActionResult CreatePayment(GetPaymentUrlByBookingCommand command)
    {
        var rs = _mediator.Send(command);
        return ApiOk(rs);
    }

    [AllowAnonymous]                
    [HttpGet("ipn")]
    public IActionResult IPN([FromQuery] IPNResponse response)
    {
        var command = new IPNPaymentCommand
        {
            IPNResponse = response
        };
        var rs = _mediator.Send(command);
        return ApiOk(rs);
    }
}
