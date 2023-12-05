using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.RestaurantFloorModels;

namespace BookingServices.Application.Services.RestaurantFloor;

public interface IRestaurantFloorServices
{
    //function for getting all restaurant floors
    Task<ApiPaged<RestaurantFloorDTO>> GetAllRestaurantFloorsAsync(GetAllRestaurantFloorRequest request);
    //function for getting restaurant floor by id
    Task<RestaurantFloorDTO> GetRestaurantFloorByIdAsync(int id);
    //function for adding restaurant floor
    Task AddRestaurantFloorAsync(AddRestaurantFloorRequest restaurantFloor);
    //function for updating restaurant floor
    Task UpdateRestaurantFloorAsync(UpdateRestaurantFloorRequest restaurantFloor);
    //function for deleting restaurant floor
    Task DeleteRestaurantFloorAsync(int id);

}
