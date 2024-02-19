using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

public class RestaurantMenu : EntityAudit<Guid>, IHaveDeleted
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string MenuUrl { get; set; }
    public Guid MenuCategoryId { get; set; }
    public EUnitType UnitType { get; set; }
    public decimal Price { get; set; }
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(MenuCategoryId))]
    public virtual MenuCategories MenuCategory { get; set; }
    public virtual ICollection<MenuImages> MenuImages { get; set; }
    public virtual ICollection<BookingMenu> BookingMenu { get; set; }
}
