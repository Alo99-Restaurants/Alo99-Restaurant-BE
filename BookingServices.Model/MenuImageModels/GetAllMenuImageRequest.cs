using BookingServices.Core.Models;

namespace BookingServices.Model.MenuImageModels;

public class GetAllMenuImageRequest : PagingRequest
{
    public Guid? RestaurantMenuId { get;set; }
}