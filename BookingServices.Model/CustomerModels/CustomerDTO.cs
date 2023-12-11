using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Entities.Enum;
using BookingServices.Model.UserModels;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.CustomerModels;

public class CustomerDTO : IEntityAudit<Guid>
{
    [EmailAddress]
    public string Email { get; set; }
    private string? _name;

    public string Name
    {
        get { return string.IsNullOrEmpty(_name) ? this.Email : _name; }
        set { _name = value; }
    }

    public EGender Gender { get; set; } = EGender.Male;
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public Guid Id { get; set; }
    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public UserDTO? User { get; set; }
}