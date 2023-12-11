using BookingServices.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.CustomerModels;

public class AddCustomerRequest(string email, string? name, EGender gender, string? phoneNumber, DateTime? dateOfBirth)
{
    [EmailAddress]
    public string Email { get; set; } = email;
    public string? Name { get; set; } = name;
    public EGender Gender { get; set; } = gender;
    public string? PhoneNumber { get; set; } = phoneNumber;
    public DateTime? DateOfBirth { get; set; } = dateOfBirth;

}