using AutoMapper;
using BookingServices.Entities.Contexts;
using BookingServices.Model.BookingModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Booking.Query
{
    public class StatisticsBookingQueryHandler : IRequestHandler<StatisticsBookingQuery, StatisticsBookingQueryResponse>
    {
        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public StatisticsBookingQueryHandler(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<StatisticsBookingQueryResponse> Handle(StatisticsBookingQuery request, CancellationToken cancellationToken)
        {
            //if request.targetdate is null or > now then = now
            if (request.TargetDate == null || request.TargetDate > DateTime.Now.Date)
            {
                request.TargetDate = DateTime.Now.Date;
            }
            //get all booking from request.TargetDate - 30 days
            var bookings = _context.Bookings
                .Where(x => x.CreatedDate >= request.TargetDate.Value.AddDays(-30).Date)
                .ToList();
            if (bookings.Count == 0)
            {
                return Task.FromResult(new StatisticsBookingQueryResponse());
            }
            //get total booking
            var totalBooking = bookings.Count;
            //get total booking success
            var totalBookingSuccess = bookings.Count(x => x.BookingStatusId == Entities.Enum.EBookingStatus.Completed);
            //get total booking failed
            var totalBookingFailed = bookings.Count(x => x.BookingStatusId == Entities.Enum.EBookingStatus.Cancelled);
            //get total booking target date
            var totalBookingTargetDate = bookings.Count(x => x.CreatedDate.Date == request.TargetDate.Value.Date);
            //get total booking last 7 days
            var totalBookingLast7Days = bookings.Count(x => x.CreatedDate.Date >= DateTime.Now.Date.AddDays(-7));
            //get total booking morning
            var totalBookingMorning = bookings.Count(x => x.CreatedDate.Hour >= 6 && x.CreatedDate.Hour < 12);
            //get total booking afternoon
            var totalBookingAfternoon = bookings.Count(x => x.CreatedDate.Hour >= 12 && x.CreatedDate.Hour < 18);
            //get total booking night
            var totalBookingNight = bookings.Count(x => x.CreatedDate.Hour >= 18 && x.CreatedDate.Hour < 24);

            return Task.FromResult(new StatisticsBookingQueryResponse
            {
                TotalBooking = totalBooking,
                TotalBookingSuccess = totalBookingSuccess,
                TotalBookingFailed = totalBookingFailed,
                TotalBookingTargetDate = totalBookingTargetDate,
                TotalBookingLast7Days = totalBookingLast7Days,
                TotalBookingMorning = totalBookingMorning,
                TotalBookingAfternoon = totalBookingAfternoon,
                TotalBookingNight = totalBookingNight
            });
        }
    }
}
