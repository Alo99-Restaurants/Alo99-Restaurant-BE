using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;

namespace BookingServices.Model.TableModels;

public class TableDTO : IEntityAudit<Guid>
{
    public Guid Id { get; set; }
    public Guid RestaurantFloorId { get; set; }
    public string TableName { get; set; }
    public int TableType { get; set; }
    public int Capacity { get; set; }
    public string ExtensionData { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
    //colection booking
    public ICollection<TableBookingDTO> Bookings { get; set; }

    public bool IsAvailable()
    {
        return Bookings?.All(x => x.BookingStatusId == EBookingStatus.Cancelled || x.BookingStatusId == EBookingStatus.Completed)??true;
    }
}
