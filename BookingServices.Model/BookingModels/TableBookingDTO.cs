using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;

namespace BookingServices.Model.TableModels;

public class TableBookingDTO : IEntityAudit<Guid>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public EBookingStatus BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}