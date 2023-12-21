using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

public class Bookings : EntityAudit<Guid>, IHaveDeleted
{

    public Guid TableId { get; set; }
    public int BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
    public bool IsDeleted { get; set; }


    [ForeignKey(nameof(TableId))]
    public virtual Tables? Table { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    public virtual Users? User { get; set; }
}
