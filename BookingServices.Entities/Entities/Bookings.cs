using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

public class Bookings : EntityAudit<Guid>, IHaveDeleted
{
    public Guid TableId { get; set; }
    public Guid CustomerId { get; set; }
    public int BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
    public bool IsDeleted { get; set; }


    [ForeignKey(nameof(TableId))]
    public virtual Tables? Table { get; set; }
    [ForeignKey(nameof(CustomerId))]
    public virtual Customers? Customer { get; set; }
    public virtual ICollection<BookingMenu> BookingMenu { get; set; }
}
