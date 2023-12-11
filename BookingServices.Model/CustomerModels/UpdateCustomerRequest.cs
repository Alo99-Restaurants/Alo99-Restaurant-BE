namespace BookingServices.Model.CustomerModels;

public class UpdateCustomerRequest(AddCustomerRequest customer, Guid id) : AddCustomerRequest(customer.Email,customer.Name,customer.Gender,customer.PhoneNumber,customer.DateOfBirth)
{
    public Guid Id { get; set; } = id;
}