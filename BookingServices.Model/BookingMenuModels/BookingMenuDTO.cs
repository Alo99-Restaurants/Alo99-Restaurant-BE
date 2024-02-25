using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Model.RestaurantMenuModels;

namespace BookingServices.Model.BookingMenuModels;

public class BookingMenuDTO : IEntityAudit<Guid>
{
    public Guid Id { get ; set ; }
    public Guid BookingId { get; set; }
    public Guid MenuId { get; set; }
    public double Quantity { get; set; }
    public double Price { get; set; }
    public string? SpecialRequest { get; set; }
    public Guid CreatedBy { get ; set ; }
    public DateTime CreatedDate { get ; set ; }
    public Guid? ModifiedBy { get ; set ; }
    public DateTime? ModifiedDate { get ; set ; }

    public RestaurantMenuDTO RestaurantMenu { get; set; }

}
