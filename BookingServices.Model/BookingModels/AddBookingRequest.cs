using BookingServices.Entities.Enum;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.BookingModels;

public class AddBookingRequest
{
    public AddBookingRequest(List<Guid> tableIds, DateTime bookingDate, int numberOfPeople, EBookingStatus bookingStatusId = EBookingStatus.New)
    {
        TableIds = tableIds;
        BookingStatusId = bookingStatusId;
        BookingDate = bookingDate;
        NumberOfPeople = numberOfPeople;
    }

    public List<Guid> TableIds { get; set; }
    public EBookingStatus BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
}