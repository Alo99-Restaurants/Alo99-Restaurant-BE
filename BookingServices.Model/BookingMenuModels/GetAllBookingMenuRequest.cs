using BookingServices.Core.Models;

namespace BookingServices.Model.BookingMenuModels;

public class GetAllBookingMenuRequest : PagingRequest
{
    public Guid? BookingId { get; set; }
    public Guid? RestaurantMenuId { get; set; }
}