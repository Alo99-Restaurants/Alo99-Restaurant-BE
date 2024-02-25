using BookingServices.Core.Models;

namespace BookingServices.Model.RestaurantMenuModels;

public class GetAllRestaurantMenuRequest : PagingRequest
{
    public Guid? MenuCategoryId { get; set; }
}