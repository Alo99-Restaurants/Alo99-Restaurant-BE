using BookingServices.Application.Services.MenuImage;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.MenuImageModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuImageController : MyControllerBase
{
    private readonly ILogger _logger;
    private readonly IMenuImageServices _menuImageServices;

    public MenuImageController(ILogger logger, IMenuImageServices menuImageServices)
    {
        _logger = logger;
        _menuImageServices = menuImageServices;
    }

    //get all menu image
    [HttpGet]
    [ProducesResponseType(typeof(ApiPaged<MenuImageDTO>), 200)]
    public async Task<IActionResult> GetAllMenuImageAsync([FromQuery] GetAllMenuImageRequest request)
    {
        return ApiOk(await _menuImageServices.GetAllMenuImageAsync(request));
    }

    //get menu image by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<MenuImageDTO>), 200)]
    public async Task<IActionResult> GetMenuImageByIdAsync(Guid id)
    {
        return ApiOk(await _menuImageServices.GetMenuImageByIdAsync(id));
    }

    //add menu image
    [HttpPost]
    [Authorize(Roles = "Admin,Manager")]
    [ProducesResponseType(typeof(ApiResult), 200)]   
    public async Task<IActionResult> AddMenuImageAsync([FromForm] AddMenuImageRequest request)
    {
        await _menuImageServices.AddMenuImageAsync(request);
        return ApiOk();
    }

    //update menu image
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateMenuImageAsync(Guid id, [FromForm] UpdateMenuImageRequest request)
    {
        await _menuImageServices.UpdateMenuImageAsync(new UpdateMenuImageRequest(request, id));
        return ApiOk();
    }

    //delete menu image
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin,Manager")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> DeleteMenuImageAsync(Guid id)
    {
        await _menuImageServices.DeleteMenuImageAsync(id);
        return ApiOk();
    }

}
