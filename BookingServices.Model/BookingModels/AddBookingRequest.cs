using BookingServices.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.BookingModels;

public class AddBookingRequest
{
    public AddBookingRequest(Guid tableId, DateTime bookingDate, int numberOfPeople, EBookingStatus bookingStatusId = EBookingStatus.New)
    {
        TableId = tableId;
        BookingStatusId = bookingStatusId;
        BookingDate = bookingDate;
        NumberOfPeople = numberOfPeople;
    }

    public Guid TableId { get; set; }
    public Guid? CustomerId { get; set; }
    public EBookingStatus BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
}