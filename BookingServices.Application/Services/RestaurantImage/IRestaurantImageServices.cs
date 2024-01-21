using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantImageModels;

namespace BookingServices.Application.Services.RestaurantImage;

public interface IRestaurantImageServices
{
    //get all restaurant image
    Task<ApiPaged<RestaurantImageDTO>> GetAllRestaurantImageAsync(GetallRestaurantImageRequest request);

    //get restaurant image by id
    Task<RestaurantImageDTO> GetRestaurantImageByIdAsync(Guid id);
    //add restaurant image
    Task AddRestaurantImageAsync(AddRestaurantImageRequest request);
    //update restaurant image
    Task UpdateRestaurantImageAsync(UpdateRestaurantImageRequest request);
    //delete restaurant image
    Task DeleteRestaurantImageAsync(Guid id);
}