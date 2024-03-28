using AutoMapper;
using BookingServices.Application.MediaR.User.Command.NewFolder;
using BookingServices.Core;
using BookingServices.Entities.Entities;
using BookingServices.Model.UserModels;

namespace BookingServices.Configs.Mappers;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDTO, Users>().ReverseMap();
        CreateMap<AddUserRequest, Users>()
             .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username.ToLower())).ReverseMap();
        CreateMap<UpdateUserRequest, Users>().ReverseMap();
        CreateMap<RegisterUserCommand, Users>()
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Utils.HashPassword(src.Password)))
            .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username.ToLower()));
    }
}
