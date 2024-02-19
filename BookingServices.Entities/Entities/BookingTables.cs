using BookingServices.Entities.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Entities.Entities
{
    public class BookingTable
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public Guid BookingId { get; set; }

        [ForeignKey(nameof(TableId))]
        public virtual Tables Table { get; set; }
        [ForeignKey(nameof(BookingId))]
        public virtual Bookings Booking { get; set; }
    }
}
