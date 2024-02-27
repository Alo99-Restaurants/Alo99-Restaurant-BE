using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using BookingServices.Model.BookingMenuModels;
using BookingServices.Model.MenuImageModels;

namespace BookingServices.Model.RestaurantMenuModels;

public class RestaurantMenuDTO : IEntityAudit<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string MenuUrl { get; set; }
    public Guid MenuCategoryId { get; set; }
    public EUnitType UnitType { get; set; }
    public decimal Price { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public IEnumerable<MenuImageDTO>? MenuImages { get; set; }
    //public IEnumerable<BookingMenuDTO>? BookingMenu { get; set; }

}