using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantModels;

namespace BookingServices.Application.Services.Restaurant;

public interface IRestaurantServices
{
    Task<ApiPaged<RestaurantDTO>> GetAllRestaurantsAsync(GetAllRestaurantRequest request);
    Task<RestaurantDTO> GetRestaurantByIdAsync(Guid id);
    Task AddRestaurantAsync(AddRestaurantRequest restaurant);
    Task UpdateRestaurantAsync(UpdateRestaurantRequest restaurant);
    Task DeleteRestaurantAsync(Guid id);
}
