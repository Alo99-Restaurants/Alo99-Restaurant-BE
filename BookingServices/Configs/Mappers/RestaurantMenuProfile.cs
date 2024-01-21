using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantMenuModels;

namespace BookingServices.Configs.Mappers;

public class RestaurantMenuProfile : Profile
{
    public RestaurantMenuProfile()
    {
        CreateMap<RestaurantMenuDTO,RestaurantMenu>().ReverseMap();
        CreateMap<AddRestaurantMenuRequest, RestaurantMenu>().ReverseMap();
        CreateMap<UpdateRestaurantMenuRequest, RestaurantMenu>().ReverseMap();
    }
}
