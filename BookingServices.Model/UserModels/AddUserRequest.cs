using BookingServices.Entities.Enum;

namespace BookingServices.Model.UserModels;

public class AddUserRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public Guid? CustomerId { get; set; }
    public ERole? Role { get; set; }

    public AddUserRequest(string username, string password, string name, Guid? customerId, ERole? role)
    {
        Username = username;
        Password = password;
        Name = name;
        CustomerId = customerId;
        Role = role;
    }
    public AddUserRequest()
    {
        
    }
}