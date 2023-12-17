using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.CustomerModels;

namespace BookingServices.Application.Services.Customer;

public interface ICustomerServices
{
    //getallcustomer
    Task<ApiPaged<CustomerDTO>> GetAllCustomersAsync(GetAllCustomerRequest request);

    //getcustomerbyid
    Task<CustomerDTO> GetCustomerByIdAsync(Guid id);

    //addcustomer
    Task<CustomerDTO> AddCustomerAsync(AddCustomerRequest customer);

    //updatecustomer
    Task UpdateCustomerAsync(UpdateCustomerRequest customer);

}