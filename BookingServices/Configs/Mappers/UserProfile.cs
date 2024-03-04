using AutoMapper;
using BookingServices.Application.MediaR.User.Command;
using BookingServices.Core;
using BookingServices.Entities.Entities;
using BookingServices.Model.UserModels;

namespace BookingServices.Configs.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, Users>().ReverseMap();
        CreateMap<AddUserRequest, Users>().ReverseMap();
        CreateMap<UpdateUserRequest, Users>().ReverseMap();
        CreateMap<RegisterUserCommand, Users>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Utils.HashPassword(src.Password)));
    }
}
