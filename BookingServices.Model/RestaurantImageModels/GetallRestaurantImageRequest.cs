using BookingServices.Core.Models;

namespace BookingServices.Model.RestaurantImageModels;

public class GetallRestaurantImageRequest : PagingRequest
{
    public Guid? RestaurantId { get; set; }
}