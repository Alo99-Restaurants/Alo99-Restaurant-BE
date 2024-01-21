using BookingServices.Core.Models;

namespace BookingServices.Model.BookingModels;

public class GetAllBookingRequest : PagingRequest
{
    public Guid? TableId { get; set; }
    public Guid? UserId { get; set; }
    public Guid? CustomerId { get; set; }
}