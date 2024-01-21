using BookingServices.Application.MediaR.Common.Email;
using BookingServices.Application.MediaR.Common.Storage.Upload;
using BookingServices.Core;
using BookingServices.Core.Identity;
using BookingServices.Core.Models.ControllerResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommonController : MyControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<CommonController> _logger;
    public CommonController(IMediator mediator, ILogger<CommonController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    //UploadStorageCommand implement api body [fromform]
    [HttpPost("storage")]
    [ProducesResponseType(typeof(ApiResult<string>), 200)]
    public async Task<IActionResult> UploadStorage([FromForm] UploadStorageCommand request)
    {
        var userId = ClaimsPrincipalExtension.GetUserId(HttpContext?.User);
        _logger.LogInformation($"UploadStorage: UserId= {userId} ; ImageKey= {request.Key??request.Files.FileName}");
        return ApiOk(await _mediator.Send(request));
    }

    //SendEmailCommand implement api body [frombody]
    [HttpPost("sendemail")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> SendEmail([FromBody] SendEmailCommand request)
    {
        var userId = ClaimsPrincipalExtension.GetUserId(HttpContext?.User);
        _logger.LogInformation($"SendEmail: UserId= {userId} ; Email= {request.To}");
        return ApiOk(await _mediator.Send(request));
    }
}
