using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.MenuImageModels;

namespace BookingServices.Application.Services.MenuImage;

public interface IMenuImageServices
{
    //get all menu image
    Task<ApiPaged<MenuImageDTO>> GetAllMenuImageAsync(GetAllMenuImageRequest request);
    //get menu image by id
    Task<MenuImageDTO> GetMenuImageByIdAsync(Guid id);
    //add menu image
    Task AddMenuImageAsync(AddMenuImageRequest request);
    //update menu image
    Task UpdateMenuImageAsync(UpdateMenuImageRequest request);
    //delete menu image
    Task DeleteMenuImageAsync(Guid id);

}