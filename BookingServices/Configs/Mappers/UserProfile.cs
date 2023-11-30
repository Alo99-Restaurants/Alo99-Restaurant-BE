using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.RestaurantModels;
using BookingServices.Model.UserModels;

namespace BookingServices.Configs.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, Users>().ReverseMap();
            CreateMap<AddUserRequest, Users>().ReverseMap();
            CreateMap<UpdateUserRequest, Users>().ReverseMap();
        }
    }
}
