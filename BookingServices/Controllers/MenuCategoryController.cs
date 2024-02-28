using BookingServices.Application.Services.MenuCategory;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.MenuCategoryModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MenuCategoryController : MyControllerBase
{
    private readonly IMenuCategoryServices _menuCategoryServices;
    private readonly ILogger _logger;
    public MenuCategoryController(IMenuCategoryServices menuCategoryServices, ILogger<MenuCategoryController> logger)
    {
        _menuCategoryServices = menuCategoryServices;
        _logger = logger;
    }
    // get all menu categories
    [HttpGet]
    [ProducesResponseType(typeof(ApiPaged<MenuCategoryDTO>), 200)]
    public async Task<IActionResult> GetAllMenuCategories([FromQuery] GetAllMenuCategoryRequest request)
    {
        var result = await _menuCategoryServices.GetAllMenuCategories(request);
        return ApiOk(result);
    }

    // get menu category by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<MenuCategoryDTO>), 200)]
    public async Task<IActionResult> GetMenuCategoryById(Guid id)
    {
        var result = await _menuCategoryServices.GetMenuCategoryById(id);
        return ApiOk(result);
    }

    // add menu category
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddMenuCategory([FromBody] AddMenuCategoryRequest request)
    {
        await _menuCategoryServices.AddMenuCategory(request);
        return ApiOk();
    }

    // update menu category
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateMenuCategory([FromBody] AddMenuCategoryRequest request, Guid id)
    {
        await _menuCategoryServices.UpdateMenuCategory(new UpdateMenuCategoryRequest (request,id));
        return ApiOk();
    }

    // delete menu category
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> DeleteMenuCategory(Guid id)
    {
        await _menuCategoryServices.DeleteMenuCategory(id);
        return ApiOk();
    }
}
