using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantMenuModels;

namespace BookingServices.Application.Services.Menu;

public interface IRestaurantMenuServices
{
    //get all restaurant menu
    Task<ApiPaged<RestaurantMenuDTO>> GetAllRestaurantMenuAsync(GetAllRestaurantMenuRequest request);
    //get restaurant menu by id
    Task<RestaurantMenuDTO> GetRestaurantMenuByIdAsync(Guid id);
    //add restaurant menu
    Task AddRestaurantMenuAsync(AddRestaurantMenuRequest request);
    //update restaurant menu
    Task UpdateRestaurantMenuAsync(UpdateRestaurantMenuRequest request);
    //delete restaurant menu
    Task DeleteRestaurantMenuAsync(Guid id);
}