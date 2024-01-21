using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.BookingMenuModels;

namespace BookingServices.Configs.Mappers;

public class BookingMenuProfile : Profile
{
    public BookingMenuProfile()
    {
        CreateMap<BookingMenuDTO, BookingMenu>().ReverseMap();
        CreateMap<AddBookingMenuRequest, BookingMenu>().ReverseMap();
        CreateMap<UpdateBookingMenuRequest, BookingMenu>().ReverseMap();
    }
}
