using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.MenuImageModels;

namespace BookingServices.Configs.Mappers;

public class MenuImageProfile : Profile
{
    public MenuImageProfile()
    {
        CreateMap<MenuImageDTO, MenuImages>().ReverseMap();
        CreateMap<AddMenuImageRequest, MenuImages>().ReverseMap();
        CreateMap<UpdateMenuImageRequest, MenuImages>().ReverseMap();
    }
}
