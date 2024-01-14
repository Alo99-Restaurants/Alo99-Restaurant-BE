using BookingServices.Core.Models;
using BookingServices.Core.Models.ControllerResponse;

namespace BookingServices.Application.Services.Booking
{
    public class GetAllBookingRequest : PagingRequest
    {
        public Guid? TableId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CustomerId { get; set; }
    }
}