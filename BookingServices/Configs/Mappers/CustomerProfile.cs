using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.CustomerModels;

namespace BookingServices.Configs.Mappers;

public class CustomerProfile : Profile
{
    public CustomerProfile()
    {
        CreateMap<CustomerDTO, Customers>().ReverseMap();
        CreateMap<AddCustomerRequest, Customers>().ReverseMap();
        CreateMap<UpdateCustomerRequest, Customers>().ReverseMap();
    }
}
