using AutoMapper;
using BookingServices.Entities.Entities;
using BookingServices.Model.BookingModels;

namespace BookingServices.Configs.Mappers;

public class BookingProfile : Profile
{
    public BookingProfile()
    {
        CreateMap<BookingDTO, Bookings>().ReverseMap();
        CreateMap<AddBookingRequest, Bookings>().ReverseMap();
        CreateMap<UpdateBookingRequest, Bookings>().ReverseMap();
    }
}
