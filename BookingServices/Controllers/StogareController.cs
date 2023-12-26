using BookingServices.Application.MediaR.Storage.Upload;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class StogareController : MyControllerBase
    {
        private readonly IMediator _mediator;
        public StogareController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //UploadStorageCommand implement api body [fromform]
        [HttpPost]
        [ProducesResponseType(typeof(ApiResult<string>), 200)]
        public async Task<IActionResult> UploadStorage([FromForm] UploadStorageCommand request) => ApiOk(await _mediator.Send(request));
      

    }
}
