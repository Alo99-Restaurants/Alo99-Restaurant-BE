using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantFloorModels;

namespace BookingServices.Configs.Mappers;

public class RestaurantFloorProfile : Profile
{
    public RestaurantFloorProfile()
    {
        CreateMap<RestaurantFloorDTO, RestaurantFloors>().ReverseMap();
        CreateMap<AddRestaurantFloorRequest, RestaurantFloors>().ReverseMap();
        CreateMap<UpdateRestaurantFloorRequest, RestaurantFloors>().ReverseMap();
    }
}
