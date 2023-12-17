using BookingServices.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.CustomerModels;

public class AddCustomerRequest
{
    [EmailAddress]
    public string Email { get; set; }
    public string? Name { get; set; }
    public EGender? Gender { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? DateOfBirth { get; set; }

    public AddCustomerRequest(string email, string? name, EGender? gender, string? phoneNumber, DateTime? dateOfBirth)
    {
        Email = email;
        Name = name;
        Gender = gender;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
    }
    public AddCustomerRequest() 
    {
        
    }
}