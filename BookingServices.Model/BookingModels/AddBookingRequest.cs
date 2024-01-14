namespace BookingServices.Application.Services.Booking
{
    public class AddBookingRequest
    {
        public AddBookingRequest(Guid tableId,Guid customerId, int bookingStatusId, DateTime bookingDate, int numberOfPeople)
        {
            TableId = tableId;
            BookingStatusId = bookingStatusId;
            BookingDate = bookingDate;
            NumberOfPeople = numberOfPeople;
            CustomerId = customerId;
        }

        public Guid TableId { get; set; }
        public Guid CustomerId { get; set; }
        public int BookingStatusId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
    }
}