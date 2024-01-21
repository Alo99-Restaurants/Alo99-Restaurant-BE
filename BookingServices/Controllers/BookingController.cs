using BookingServices.Application.Services.Booking;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.BookingModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingController : MyControllerBase
{
    private readonly IBookingServices _bookingServices;
    private readonly ILogger<BookingController> _logger;

    public BookingController(IBookingServices bookingServices, ILogger<BookingController> logger)
    {
        _bookingServices = bookingServices;
        _logger = logger;
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

}
