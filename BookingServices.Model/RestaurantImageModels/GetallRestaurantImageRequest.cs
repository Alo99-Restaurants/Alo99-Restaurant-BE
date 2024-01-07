
using BookingServices.Core.Models;

namespace BookingServices.Application.Services.RestaurantImage;

public class GetallRestaurantImageRequest : PagingRequest
{
    public Guid? RestaurantId { get; set; }
}