using BookingServices.Model.TableModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Table.Query
{
    public class FindTableForBookingQuery : IRequest<IEnumerable<TableDTO>>
    {
        public Guid? RestaurantId { get; set; }
        public int Capacity { get; set; }
        public DateTime BookingDate { get; set; }
    }
}
