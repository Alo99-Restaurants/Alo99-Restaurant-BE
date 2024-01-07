using BookingServices.Core.Models;

namespace BookingServices.Application.Services.Table;

public class GetAllTableRequest : PagingRequest
{
    public Guid? RestaurantFloorId { get; set; }
}