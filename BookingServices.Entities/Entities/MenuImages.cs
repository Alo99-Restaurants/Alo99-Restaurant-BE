using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

public class MenuImages : EntityAudit<Guid>, IHaveDeleted
{
    public Guid MenuId { get; set; }
    public string ImageUrl { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(MenuId))]
    public virtual RestaurantMenu RestaurantMenu { get; set; }
}
