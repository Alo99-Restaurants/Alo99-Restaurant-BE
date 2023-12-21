using BookingServices.Core.Models;

namespace BookingServices.Application.Services.Table
{
    public class GetAllTableRequest : PagingRequest
    {
        public int? RestaurantFloorId { get; set; }
    }
}