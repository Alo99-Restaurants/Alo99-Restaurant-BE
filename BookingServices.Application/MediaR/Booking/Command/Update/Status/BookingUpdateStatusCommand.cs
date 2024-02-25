using BookingServices.Entities.Enum;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Booking.Command.Update.Status
{
    public class BookingUpdateStatusCommand : IRequest<bool>
    {
        public List<Guid> BookingIds { get; set; }
        public EBookingStatus BookingStatus { get; set; }
    }
}
