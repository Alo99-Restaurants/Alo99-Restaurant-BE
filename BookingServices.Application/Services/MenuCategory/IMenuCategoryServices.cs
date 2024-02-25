using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.MenuCategoryModels;

namespace BookingServices.Application.Services.MenuCategory;

public interface IMenuCategoryServices
{
    //get all menu categories
    Task<ApiPaged<MenuCategoryDTO>> GetAllMenuCategories(GetAllMenuCategoryRequest request);
    //get menu category by id
    Task<MenuCategoryDTO> GetMenuCategoryById(Guid id);
    //add menu category
    Task AddMenuCategory(AddMenuCategoryRequest request);
    //update menu category
    Task UpdateMenuCategory(UpdateMenuCategoryRequest request);
    //delete menu category
    Task DeleteMenuCategory(Guid id);
}