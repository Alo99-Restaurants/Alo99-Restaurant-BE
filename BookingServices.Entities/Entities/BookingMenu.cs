using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

public class BookingMenu : EntityAudit<Guid>, IHaveDeleted
{
    public Guid BookingId { get; set; }
    public Guid MenuId { get; set; }
    public double Quantity { get; set; }
    public string? SpecialRequest { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(MenuId))]
    public virtual Bookings Booking { get; set; }
    [ForeignKey(nameof(MenuId))]
    public virtual RestaurantMenu RestaurantMenu { get; set; }
}
