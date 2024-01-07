using BookingServices.Application.Services.Restaurant;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RestaurantController : MyControllerBase
{
    private readonly IRestaurantServices _restaurantServices;

    public RestaurantController(IRestaurantServices restaurantServices)
    {
        _restaurantServices = restaurantServices;
    }

    // GET: api/Restaurant
    [HttpGet]
    [ProducesResponseType(typeof(ApiPaged<RestaurantDTO>), 200)]
    public async Task<IActionResult> GetRestaurants([FromQuery] GetAllRestaurantRequest request) => ApiOk(await _restaurantServices.GetAllRestaurantsAsync(request));

    // GET: api/Restaurant/5
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<RestaurantDTO>), 200)]
    public async Task<IActionResult> GetRestaurant(Guid id) => ApiOk(await _restaurantServices.GetRestaurantByIdAsync(id));

    // POST: api/Restaurant
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddRestaurant(AddRestaurantRequest restaurant)
    {
        await _restaurantServices.AddRestaurantAsync(restaurant);
        return ApiOk();
    }

    // PUT: api/Restaurant/5
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateRestaurant(Guid id, AddRestaurantRequest restaurant)
    {
        await _restaurantServices.UpdateRestaurantAsync(new UpdateRestaurantRequest(restaurant, id));
        return ApiOk();
    }

    // DELETE: api/Restaurant/5
    [HttpDelete("{id}")]
    public async Task DeleteRestaurant(Guid id)
    {
        await _restaurantServices.DeleteRestaurantAsync(id);
    }
}
