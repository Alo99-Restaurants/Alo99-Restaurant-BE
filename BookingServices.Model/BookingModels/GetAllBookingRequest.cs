using BookingServices.Core.Models;
using BookingServices.Entities.Enum;

namespace BookingServices.Model.BookingModels;

public class GetAllBookingRequest : PagingRequest
{
    public Guid? TableId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CustomerId { get; set; }
    public Guid? RestaurantId { get; set; }
    public DateTime? BookingDate { get; set; }
    public List<EBookingStatus>? BookingStatus { get; set; }
}