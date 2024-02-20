using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

public class Bookings : EntityAudit<Guid>, IHaveDeleted
{
    public Guid? CustomerId { get; set; }
    public EBookingStatus BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
    public bool IsDeleted { get; set; }
    
    [ForeignKey(nameof(CustomerId))]
    public Customers? Customer { get; set; }
    public ICollection<BookingMenu> BookingMenu { get; set; }
    public ICollection<Tables> Tables { get; set; } = [];
}
