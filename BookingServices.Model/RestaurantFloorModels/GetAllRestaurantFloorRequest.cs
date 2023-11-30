using BookingServices.Core.Models;

namespace BookingServices.Model.RestaurantFloorModels
{
    public class GetAllRestaurantFloorRequest : PagingRequest
    {
        public int? RestaurantId { get; set; }
    }
}