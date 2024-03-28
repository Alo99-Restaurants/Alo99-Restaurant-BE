using BookingServices.Application.Services.Booking;
using Hangfire;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application
{
    public class BackgroundJobConfig
    {
        public void ConfigureJobs()
        {
            RecurringJob.AddOrUpdate<IBookingServices>("CheckBookingStatus", x=> x.CheckBookingStatus(), "*/5 * * * *");
        }
    }
}
