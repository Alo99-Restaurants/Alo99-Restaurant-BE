using BookingServices.Application.Services.RestaurantFloor;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantFloorModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RestaurantFloorController : MyControllerBase
{
    private readonly IRestaurantFloorServices _restaurantFloorServices;

    public RestaurantFloorController(IRestaurantFloorServices restaurantFloorServices)
    {
        _restaurantFloorServices = restaurantFloorServices;
    }

    //get all restaurant floors
    [HttpGet("")]
    [ProducesResponseType(typeof(ApiPaged<RestaurantFloorDTO>), 200)]
    public async Task<IActionResult> GetRestaurantFloors([FromQuery] GetAllRestaurantFloorRequest request) => ApiOk(await _restaurantFloorServices.GetAllRestaurantFloorsAsync(request));

    //get restaurant floor by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<RestaurantFloorDTO>), 200)]
    public async Task<IActionResult> GetRestaurantFloor(Guid id) => ApiOk(await _restaurantFloorServices.GetRestaurantFloorByIdAsync(id));

    //add restaurant floor
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddRestaurantFloor(AddRestaurantFloorRequest restaurantFloor)
    {
        await _restaurantFloorServices.AddRestaurantFloorAsync(restaurantFloor);
        return ApiOk();
    }

    //update restaurant floor
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateRestaurantFloor(Guid id, AddRestaurantFloorRequest restaurantFloor)
    {
        await _restaurantFloorServices.UpdateRestaurantFloorAsync(new UpdateRestaurantFloorRequest(restaurantFloor, id));
        return ApiOk();
    }

    //delete restaurant floor
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task DeleteRestaurantFloor(Guid id)
    {
        await _restaurantFloorServices.DeleteRestaurantFloorAsync(id);
    }
}
