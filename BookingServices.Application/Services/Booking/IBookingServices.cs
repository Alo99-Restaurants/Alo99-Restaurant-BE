using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.BookingModels;

namespace BookingServices.Application.Services.Booking;

public interface IBookingServices
{
    //get all
    Task<ApiPaged<BookingDTO>> GetAllBookingAsync(GetAllBookingRequest request);
    //get by id
    Task<BookingDTO?> GetBookingByIdAsync(Guid id);
    //add
    Task AddBookingAsync(AddBookingRequest request);
    //update
    Task UpdateBookingAsync(UpdateBookingRequest request);
    //delete
    Task DeleteBookingAsync(Guid id);
}