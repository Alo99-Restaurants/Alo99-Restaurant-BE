using BookingServices.Entities.Enum;

namespace BookingServices.Model.UserModels
{
    public class AddUserRequest
    {
        public AddUserRequest(string username, string password, string name, bool isCustomer, Guid? customerId, ERole? role)
        {
            Username = username;
            Name = name;
            IsCustomer = isCustomer;
            CustomerId = customerId;
            Role = role;
        }

        public string Username { get;set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public bool IsCustomer { get; set; }
        public Guid? CustomerId { get; set; }
        public ERole? Role { get; set; }
    }
}