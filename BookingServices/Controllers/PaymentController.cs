using BookingServices.Application.MediaR.Payment.Command;
using BookingServices.Application.MediaR.Payment.Query.Url;
using BookingServices.Core;
using BookingServices.External.Model.VNPay.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    public async Task<IActionResult> CreatePayment(GetPaymentUrlByBookingCommand command)
    {
        var rs =await _mediator.Send(command);
        return ApiOk(rs);
    }
                
    [HttpGet("ipn")]
    [AllowAnonymous]
    public async Task<IActionResult> IPN([FromQuery] IPNRequest request)
    {
        _logger.LogInformation("IPN: {@response}", JsonConvert.SerializeObject(request));
        var command = new IPNPaymentCommand
        {
            IPNRequest = request
        };
        var rs =await _mediator.Send(command);
        return Ok(rs);
    }
}
