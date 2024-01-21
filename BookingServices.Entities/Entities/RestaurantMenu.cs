using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;

namespace BookingServices.Entities.Entities;

public class RestaurantMenu : EntityAudit<Guid>, IHaveDeleted
{
    public string Name { get; set; }
    public string Description { get; set; }
    public EMenuType MenuType { get; set; }
    public EUnitType UnitType { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<MenuImages> MenuImages { get; set; }
    public virtual ICollection<BookingMenu> BookingMenu { get; set; }
}
