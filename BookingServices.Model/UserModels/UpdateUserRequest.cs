using BookingServices.Entities.Enum;

namespace BookingServices.Model.UserModels;

public class UpdateUserRequest(UpdateUserData request, Guid id) : UpdateUserData(request.Name, request.CustomerId, request.Role)
{
    public Guid Id { get; set; } = id;
}
public class UpdateUserData(string name, Guid? customerId, ERole? role)
{
    public string Name { get; set; } = name;
    public Guid? CustomerId { get; set; } = customerId;
    public ERole? Role { get; set; } = role;
}