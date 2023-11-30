using AutoMapper;
using BookingServices.Application.MediaR.Restaurant.Command.Insert;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantModels;

namespace BookingServices.Configs.Mappers
{
    public class RestaurantProfile : Profile
    {
        public RestaurantProfile()
        {
            CreateMap<RestaurantDTO, Restaurants>().ReverseMap();
            CreateMap<AddRestaurantRequest, Restaurants>().ReverseMap();
            CreateMap<UpdateRestaurantRequest, Restaurants>().ReverseMap();

            CreateMap<InsertRestaurantCommand, Restaurants>().ReverseMap();
        }
    }
}
