using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Model.RestaurantMenuModels;

namespace BookingServices.Model.MenuImageModels;

public class MenuImageDTO : IEntityAudit<Guid>
{
    public Guid Id { get; set; }
    public Guid MenuId { get; set; }
    public string ImageUrl { get; set; }
    public Guid CreatedBy { get ; set ; }
    public DateTime CreatedDate { get ; set ; }
    public Guid? ModifiedBy { get ; set ; }
    public DateTime? ModifiedDate { get ; set ; }

    public RestaurantMenuDTO? RestaurantMenu { get; set; }
}
