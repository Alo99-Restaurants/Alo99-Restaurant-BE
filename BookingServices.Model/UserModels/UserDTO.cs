using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;

namespace BookingServices.Model.UserModels;

public class UserDTO : IEntityAudit<Guid>, IHaveDeleted
{
    //implement interface
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid? CustomerId { get; set; }
    public ERole Role { get; set; }

    public bool IsDeleted { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
