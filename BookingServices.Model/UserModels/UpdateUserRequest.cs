using BookingServices.Entities.Enum;

namespace BookingServices.Model.UserModels;

public class UpdateUserRequest : UpdateUserData
{

    public UpdateUserRequest(UpdateUserData request, Guid id) : base(request.Name, request.IsCustomer, request.CustomerId, request.Role)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}
public class UpdateUserData
{
    public string Name { get; set; }
    public bool IsCustomer { get; set; }
    public Guid? CustomerId { get; set; }
    public ERole? Role { get; set; }

    public UpdateUserData(string name, bool isCustomer, Guid? customerId, ERole? role)
    {
        this.Name = name;
        this.IsCustomer = isCustomer;
        this.CustomerId = customerId;
        this.Role = role;
    }
}