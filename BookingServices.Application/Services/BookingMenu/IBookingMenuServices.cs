using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.BookingMenuModels;

namespace BookingServices.Application.Services.BookingMenu;

public interface IBookingMenuServices
{
    //get all booking menu
    Task<ApiPaged<BookingMenuDTO>> GetAllBookingMenuAsync(GetAllBookingMenuRequest request);
    //get booking menu by id
    Task<BookingMenuDTO> GetBookingMenuByIdAsync(Guid id);
    //add booking menu
    Task AddBookingMenuAsync(AddBookingMenuRequest request);
    //update booking menu
    Task UpdateBookingMenuAsync(UpdateBookingMenuRequest request);
    //delete booking menu
    Task DeleteBookingMenuAsync(Guid id);
}