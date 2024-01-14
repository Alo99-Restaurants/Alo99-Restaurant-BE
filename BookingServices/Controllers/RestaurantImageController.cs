using BookingServices.Application.Services.RestaurantImage;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RestaurantImageController : MyControllerBase
    {
        private readonly IRestaurantImageServices _restaurantImageServices;
        public RestaurantImageController(IRestaurantImageServices restaurantImageServices)
        {
            _restaurantImageServices = restaurantImageServices;
        }

        //get all restaurant images
        [HttpGet("")]
        [ProducesResponseType(typeof(ApiPaged<RestaurantImageDTO>), 200)]
        public async Task<IActionResult> GetAllRestaurantImages([FromQuery] GetallRestaurantImageRequest request) => ApiOk(await _restaurantImageServices.GetAllRestaurantImageAsync(request));

        //get restaurant image by id
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResult<RestaurantImageDTO>), 200)]
        public async Task<IActionResult> GetRestaurantImage(Guid id) => ApiOk(await _restaurantImageServices.GetRestaurantImageByIdAsync(id));

        //add restaurant image
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResult), 200)]
        public async Task<IActionResult> AddRestaurantImage([FromBody] AddRestaurantImageRequest restaurantImage)
        {
            await _restaurantImageServices.AddRestaurantImageAsync(restaurantImage);
            return ApiOk();
        }

        //update restaurant image
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResult), 200)]
        public async Task<IActionResult> UpdateRestaurantImage(Guid id, AddRestaurantImageRequest restaurantImage)
        {
            await _restaurantImageServices.UpdateRestaurantImageAsync(new UpdateRestaurantImageRequest(restaurantImage, id));
            return ApiOk();
        }

        //delete restaurant image
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(ApiResult), 200)]
        public async Task<IActionResult> DeleteRestaurantImage(Guid id)
        {
            await _restaurantImageServices.DeleteRestaurantImageAsync(id);
            return ApiOk();
        }
    }
}
