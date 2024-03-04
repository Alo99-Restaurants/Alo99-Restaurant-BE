namespace BookingServices.Model.CustomerModels;

public class UpdateCustomerRequest(AddCustomerRequest customer, Guid id) : AddCustomerRequest(customer.Email,customer.EmailConfirmed,customer.Name,customer.Gender,customer.PhoneNumber,customer.DateOfBirth,customer.Picture)
{
    public Guid Id { get; set; } = id;
}