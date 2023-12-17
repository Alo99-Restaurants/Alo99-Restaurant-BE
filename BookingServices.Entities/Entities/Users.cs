using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities;

[Index("Username", IsUnique = true)]
[Index("CustomerId", IsUnique = true)]
public class Users : EntityAudit<Guid>, IHaveDeleted
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public Guid? CustomerId { get; set; }
    public ERole Role { get; set; } = ERole.Staff;
    public bool IsDeleted { get; set; }

    [ForeignKey(nameof(CustomerId))]
    public virtual Customers? Customer { get; set; }
}
