using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.MenuCategoryModels;

namespace BookingServices.Configs.Mappers;

public class MenuCategoryProfile: Profile
{
    public MenuCategoryProfile()
    {
        CreateMap<MenuCategoryDTO, MenuCategories>().ReverseMap();
        CreateMap<AddMenuCategoryRequest, MenuCategories>().ReverseMap();
        CreateMap<UpdateMenuCategoryRequest, MenuCategories>().ReverseMap();
    }
}
