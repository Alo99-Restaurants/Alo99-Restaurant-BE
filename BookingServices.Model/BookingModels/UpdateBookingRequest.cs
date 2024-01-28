namespace BookingServices.Model.BookingModels;

public class UpdateBookingRequest : AddBookingRequest
{
    public UpdateBookingRequest(AddBookingRequest request, Guid id) : base(request.TableId, request.CustomerId, request.BookingDate, request.NumberOfPeople, request.BookingStatusId)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}