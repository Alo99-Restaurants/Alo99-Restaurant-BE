using AutoMapper;
using BookingServices.Application.Services.RestaurantImage;
using BookingServices.Entities.Entities;

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
