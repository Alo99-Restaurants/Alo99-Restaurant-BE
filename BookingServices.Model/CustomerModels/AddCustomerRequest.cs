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
    public string? Picture { get; set; }
    public bool EmailConfirmed { get; set; }

    public AddCustomerRequest(string email,bool emailConfirmed, string? name, EGender? gender, string? phoneNumber, DateTime? dateOfBirth, string? picture)
    {
        Email = email;
        Name = name;
        Gender = gender;
        PhoneNumber = phoneNumber;
        DateOfBirth = dateOfBirth;
        Picture = picture;
        EmailConfirmed = emailConfirmed;
    }
    public AddCustomerRequest() 
    {
        
    }
}