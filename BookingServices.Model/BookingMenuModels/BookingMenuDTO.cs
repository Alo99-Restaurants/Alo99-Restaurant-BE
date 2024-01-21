using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Model.BookingMenuModels;

public class BookingMenuDTO : IEntityAudit<Guid>
{
    public Guid Id { get ; set ; }
    public Guid BookingId { get; set; }
    public Guid MenuId { get; set; }
    public double Quantity { get; set; }
    public string? SpecialRequest { get; set; }
    public Guid CreatedBy { get ; set ; }
    public DateTime CreatedDate { get ; set ; }
    public Guid? ModifiedBy { get ; set ; }
    public DateTime? ModifiedDate { get ; set ; }

}
