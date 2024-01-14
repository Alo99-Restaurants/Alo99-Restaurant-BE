using AutoMapper;
using BookingServices.Application.Services.Booking;
using BookingServices.Entities.Entities;
using BookingServices.Model.BookingModels;

namespace BookingServices.Configs.Mappers
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingDTO, Bookings>().ReverseMap();
            CreateMap<AddBookingRequest, Bookings>().ReverseMap();
            CreateMap<UpdateBookingRequest, Bookings>().ReverseMap();
        }
    }
}
