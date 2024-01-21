using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Model.TableModels;

namespace BookingServices.Model.RestaurantFloorModels;

public class RestaurantFloorDTO : IEntityAudit<Guid>
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    public int Capacity { get; set; }
    public string? LayoutUrl { get; set; }
    public string? ExtensionData { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public IEnumerable<TableDTO>? Tables { get; set; }
    
    
}
