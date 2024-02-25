using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Model.RestaurantMenuModels;

namespace BookingServices.Model.MenuCategoryModels;

public class MenuCategoryDTO : IEntityAudit<Guid>, IHaveDeleted
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string IconUrl { get; set; }
    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public IEnumerable<RestaurantMenuDTO> RestaurantMenus { get; set; } 
}