using BookingServices.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.BookingModels;

public class AddBookingRequest
{
    public AddBookingRequest(List<Guid> tableIds,Guid restaurantId, DateTime bookingDate, int numberOfPeople, string? note, EBookingStatus bookingStatusId = EBookingStatus.New)
    {
        TableIds = tableIds;
        BookingStatusId = bookingStatusId;
        BookingDate = bookingDate;
        NumberOfPeople = numberOfPeople;
        Note = note;
        RestaurantId = restaurantId;
    }

    public List<Guid> TableIds { get; set; }
    [Required]
    public Guid RestaurantId { get; set; }
    public EBookingStatus BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
    public string? Note { get; set; }
}