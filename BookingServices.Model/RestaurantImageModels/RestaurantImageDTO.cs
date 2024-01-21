using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Model.RestaurantImageModels;

public class RestaurantImageDTO : IEntityAudit<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }

}