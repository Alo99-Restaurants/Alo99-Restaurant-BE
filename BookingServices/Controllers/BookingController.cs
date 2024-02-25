using BookingServices.Application.MediaR.Booking.Command.Remove.All;
using BookingServices.Application.MediaR.Booking.Command.Update.Status;
using BookingServices.Application.Services.Booking;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.BookingModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : MyControllerBase
{
    private readonly IMediator _mediator;
    private readonly IBookingServices _bookingServices;
    private readonly ILogger<BookingController> _logger;

    public BookingController(IBookingServices bookingServices, ILogger<BookingController> logger, IMediator mediator)
    {
        _bookingServices = bookingServices;
        _logger = logger;
        _mediator = mediator;
    }

    //get all booking
    [HttpGet("")]
    [ProducesResponseType(typeof(ApiPaged<BookingDTO>), 200)]
    public async Task<IActionResult> GetAllBooking([FromQuery] GetAllBookingRequest request) => ApiOk(await _bookingServices.GetAllBookingAsync(request));

    //get booking by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<BookingDTO>), 200)]
    public async Task<IActionResult> GetBookingById(Guid id) => ApiOk(await _bookingServices.GetBookingByIdAsync(id));

    //add booking
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddBooking([FromBody] AddBookingRequest booking)
    {
        await _bookingServices.AddBookingAsync(booking);
        return ApiOk();
    }

    //update booking
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateBooking(Guid id, AddBookingRequest booking)
    {
        await _bookingServices.UpdateBookingAsync(new UpdateBookingRequest(booking, id));
        return ApiOk();
    }

    //delete booking
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> DeleteBooking(Guid id)
    {
        await _bookingServices.DeleteBookingAsync(id);
        return ApiOk();
    }

    //implement api of BookingUpdateStatusCommand
    [HttpPost("update-status")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateStatus(BookingUpdateStatusCommand command)
    {
        return ApiOk(await _mediator.Send(command));
    }

    //implement api of BookingRemoveAllCommand
    [HttpPost("remove-all")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> RemoveAll()
    {
        return ApiOk(await _mediator.Send(new BookingRemoveAllCommand()));
    }

}
