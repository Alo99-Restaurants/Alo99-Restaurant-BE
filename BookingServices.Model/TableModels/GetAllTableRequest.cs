using BookingServices.Core.Models;

namespace BookingServices.Model.TableModels;

public class GetAllTableRequest : PagingRequest
{
    public Guid? RestaurantFloorId { get; set; }
}