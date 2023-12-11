using BookingServices.Entities.Enum;

namespace BookingServices.Model.UserModels;

public class AddUserRequest(string username, string password, string name, Guid? customerId, ERole? role)
{
    public string Username { get; set; } = username;
    public string Password { get; set; } = password;
    public string Name { get; set; } = name;
    public Guid? CustomerId { get; set; } = customerId;
    public ERole? Role { get; set; } = role;
}