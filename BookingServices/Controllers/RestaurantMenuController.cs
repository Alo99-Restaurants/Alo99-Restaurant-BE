using BookingServices.Application.Services.Menu;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantMenuModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RestaurantMenuController : MyControllerBase
{
    private readonly IRestaurantMenuServices _restaurantMenuServices;
    private readonly ILogger _logger;

    public RestaurantMenuController(IRestaurantMenuServices restaurantMenuServices, ILogger<RestaurantMenuController> logger)
    {
        _restaurantMenuServices = restaurantMenuServices;
        _logger = logger;
    }

    //get all restaurant menu
    [HttpGet]
    [ProducesResponseType(typeof(ApiPaged<RestaurantMenuDTO>), 200)]
    public async Task<IActionResult> GetAllRestaurantMenuAsync([FromQuery] GetAllRestaurantMenuRequest request) => Ok(await _restaurantMenuServices.GetAllRestaurantMenuAsync(request));

    //get restaurant menu by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<RestaurantMenuDTO>), 200)]
    public async Task<IActionResult> GetRestaurantMenuByIdAsync(Guid id) => Ok(await _restaurantMenuServices.GetRestaurantMenuByIdAsync(id));

    //add restaurant menu
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> AddRestaurantMenuAsync([FromBody] AddRestaurantMenuRequest request)
    {
        await _restaurantMenuServices.AddRestaurantMenuAsync(request);
        return Ok();
    }

    //update restaurant menu
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> UpdateRestaurantMenuAsync(Guid id, [FromBody] AddRestaurantMenuRequest request)
    {
        
        await _restaurantMenuServices.UpdateRestaurantMenuAsync(new UpdateRestaurantMenuRequest(id,request));
        return Ok();
    }

    //delete restaurant menu
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    [Authorize(Roles = "Admin,Manager")]
    public async Task<IActionResult> DeleteRestaurantMenuAsync(Guid id)
    {
        await _restaurantMenuServices.DeleteRestaurantMenuAsync(id);
        return Ok();
    }
}
