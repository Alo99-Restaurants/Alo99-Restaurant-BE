using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantImageModels;

namespace BookingServices.Configs.Mappers;

public class RestaurantImageProfile : Profile
{
    public RestaurantImageProfile()
    {
        CreateMap<RestaurantImageDTO, RestaurantImages>().ReverseMap();
        CreateMap<AddRestaurantImageRequest, RestaurantImages>().ReverseMap();
        CreateMap<UpdateRestaurantImageRequest, RestaurantImages>().ReverseMap();

    }
}
