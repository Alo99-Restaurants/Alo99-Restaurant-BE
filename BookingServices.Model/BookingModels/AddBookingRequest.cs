using BookingServices.Entities.Enum;

namespace BookingServices.Model.BookingModels;

public class AddBookingRequest
{
    public AddBookingRequest(Guid tableId, Guid customerId, DateTime bookingDate, int numberOfPeople, EBookingStatus bookingStatusId = EBookingStatus.New)
    {
        TableId = tableId;
        BookingStatusId = bookingStatusId;
        BookingDate = bookingDate;
        NumberOfPeople = numberOfPeople;
        CustomerId = customerId;
    }

    public Guid TableId { get; set; }
    public Guid CustomerId { get; set; }
    public EBookingStatus BookingStatusId { get; set; }
    public DateTime BookingDate { get; set; }
    public int NumberOfPeople { get; set; }
}