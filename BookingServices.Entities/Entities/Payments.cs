using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

public class Payments : EntityAudit<Guid>, IHaveDeleted
{
    public Guid TransactionId { get; set; }
    public Guid BookingId { get; set; }
    public double Amount { get; set; }
    public bool IsDeleted { get ; set; }

    [ForeignKey("TransactionId")]
    public virtual Transaction Transaction { get; set; }
    [ForeignKey("BookingId")]
    public virtual Bookings Booking { get; set; }

}
