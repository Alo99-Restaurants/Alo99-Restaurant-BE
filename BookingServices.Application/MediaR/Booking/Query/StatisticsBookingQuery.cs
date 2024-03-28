using BookingServices.Model.BookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Booking.Query
{
    public class StatisticsBookingQuery : IRequest<StatisticsBookingQueryResponse>
    {
        public DateTime? TargetDate { get; set; }
    }
}
