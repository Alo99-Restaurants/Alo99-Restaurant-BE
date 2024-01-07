using BookingServices.Application.MediaR.Storage.Upload;
using BookingServices.Core;
using BookingServices.Core.Identity;
using BookingServices.Core.Models.ControllerResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize()]
public class StogareController : MyControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<StogareController> _logger;
    public StogareController(IMediator mediator, ILogger<StogareController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    //UploadStorageCommand implement api body [fromform]
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult<string>), 200)]
    public async Task<IActionResult> UploadStorage([FromForm] UploadStorageCommand request)
    {
        var userId = ClaimsPrincipalExtension.GetUserId(HttpContext?.User);
        _logger.LogInformation($"UploadStorage: UserId= {userId} ; ImageKey= {request.Key??request.Files.FileName}");
        return ApiOk(await _mediator.Send(request));
    }
}
