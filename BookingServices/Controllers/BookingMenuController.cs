using BookingServices.Application.MediaR.BookingMenus.Command;
using BookingServices.Application.Services.BookingMenu;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.BookingMenuModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingMenuController : MyControllerBase
{
    private readonly ILogger _logger;
    private readonly IBookingMenuServices _bookingMenuServices;
    private readonly IMediator _mediator;

    public BookingMenuController(ILogger<BookingMenuController> logger, IBookingMenuServices bookingMenuServices, IMediator mediator)
    {
        _logger = logger;
        _bookingMenuServices = bookingMenuServices;
        _mediator = mediator;
    }

    //get all booking menu
    [HttpGet]
    [ProducesResponseType(typeof(ApiPaged<BookingMenuDTO>), 200)]
    public async Task<IActionResult> GetAllBookingMenuAsync([FromQuery] GetAllBookingMenuRequest request) => ApiOk(await _bookingMenuServices.GetAllBookingMenuAsync(request));

    //get booking menu by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<BookingMenuDTO>), 200)]
    public async Task<IActionResult> GetBookingMenuByIdAsync(Guid id) => ApiOk(await _bookingMenuServices.GetBookingMenuByIdAsync(id));

    //add booking menu
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddBookingMenuAsync([FromBody] AddBookingMenuRequest request)
    {
        await _bookingMenuServices.AddBookingMenuAsync(request);
        return ApiOk();
    }

    //update booking menu
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateBookingMenuAsync(Guid id, [FromBody] UpdateBookingBody request)
    {
        await _bookingMenuServices.UpdateBookingMenuAsync(new UpdateBookingMenuRequest(request,id));
        return ApiOk();
    }

    //delete booking menu
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> DeleteBookingMenuAsync(Guid id)
    {
        await _bookingMenuServices.DeleteBookingMenuAsync(id);
        return ApiOk();
    }

    //implement CreatesOrUpdatesBookingMenuCommandHandler api
    [HttpPost("CreatesOrUpdatesBookingMenu")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> CreatesOrUpdatesBookingMenu([FromBody] CreatesOrUpdatesBookingMenuCommand request)
    {
        await _mediator.Send(request);
        return ApiOk();
    }
}
