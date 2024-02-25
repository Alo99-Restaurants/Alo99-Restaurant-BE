using BookingServices.Entities.Entities;
using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using BookingServices.Model.RestaurantModels;
using BookingServices.Model.TableModels;
using BookingServices.Model.UserModels;

namespace BookingServices.Model.BookingModels;

public class BookingDTO : IEntityAudit<Guid>
{
    public Guid Id { get; set; }
    public Guid RestaurantId { get; set; }
    public Guid CustomerId { get; set; }
    public EBookingStatus BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
    public string? Note { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public RestaurantDTO Restaurant { get; set; }
    public ICollection<BookingTableDTO> Tables { get; set; } = [];
}
