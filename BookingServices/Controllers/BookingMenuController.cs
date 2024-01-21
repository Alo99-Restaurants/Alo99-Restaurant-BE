using BookingServices.Application.Services.BookingMenu;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.BookingMenuModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingMenuController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly IBookingMenuServices _bookingMenuServices;

    public BookingMenuController(ILogger<BookingMenuController> logger, IBookingMenuServices bookingMenuServices)
    {
        _logger = logger;
        _bookingMenuServices = bookingMenuServices;
    }

    //get all booking menu
    [HttpGet]
    [ProducesResponseType(typeof(ApiPaged<BookingMenuDTO>), 200)]
    public async Task<IActionResult> GetAllBookingMenuAsync([FromQuery] GetAllBookingMenuRequest request) => Ok(await _bookingMenuServices.GetAllBookingMenuAsync(request));

    //get booking menu by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<BookingMenuDTO>), 200)]
    public async Task<IActionResult> GetBookingMenuByIdAsync(Guid id) => Ok(await _bookingMenuServices.GetBookingMenuByIdAsync(id));

    //add booking menu
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddBookingMenuAsync([FromBody] AddBookingMenuRequest request)
    {
        await _bookingMenuServices.AddBookingMenuAsync(request);
        return Ok();
    }

    //update booking menu
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateBookingMenuAsync(Guid id, [FromBody] UpdateBookingBody request)
    {
        await _bookingMenuServices.UpdateBookingMenuAsync(new UpdateBookingMenuRequest(request,id));
        return Ok();
    }

    //delete booking menu
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> DeleteBookingMenuAsync(Guid id)
    {
        await _bookingMenuServices.DeleteBookingMenuAsync(id);
        return Ok();
    }


}
