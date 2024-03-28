using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Model.BookingModels
{
    public class StatisticsBookingQueryResponse
    {
        public int TotalBooking { get; set; }
        public int TotalBookingSuccess { get; set; }
        public int TotalBookingFailed { get; set; }
        public int TotalBookingTargetDate { get; set; }
        public int TotalBookingLast7Days { get; set; }
        //booking at morning
        public int TotalBookingMorning { get; set; }
        //booking at afternoon
        public int TotalBookingAfternoon { get; set; }
        //booking at night
        public int TotalBookingNight { get; set; }
    }
}
