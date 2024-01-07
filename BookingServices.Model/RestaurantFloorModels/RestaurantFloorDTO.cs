using BookingServices.Entities.Entities;
using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Model.RestaurantFloorModels;

public class RestaurantFloorDTO : EntityAudit<Guid>
{
    public Guid RestaurantId { get; set; }
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    public int Capacity { get; set; }
    public string? LayoutUrl { get; set; }
    public string? ExtensionData { get; set; }

    public IEnumerable<Tables>? Tables { get; set; }
}
