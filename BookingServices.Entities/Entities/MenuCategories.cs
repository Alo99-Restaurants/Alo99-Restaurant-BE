using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Entities.Entities;

public class MenuCategories : EntityAudit<Guid>, IHaveDeleted
{
    public string Name { get; set; }
    public string IconUrl { get; set; }
    public bool IsDeleted { get; set; }
    public virtual ICollection<RestaurantMenu> RestaurantMenus { get; set; }
}
