using BookingServices.Core.Models;

namespace BookingServices.Model.CustomerModels;

public class GetAllCustomerRequest : PagingRequest
{
    public string SearchText { get; set; }
}