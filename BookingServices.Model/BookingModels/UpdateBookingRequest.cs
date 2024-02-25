namespace BookingServices.Model.BookingModels;

public class UpdateBookingRequest : AddBookingRequest
{
    public UpdateBookingRequest(AddBookingRequest request, Guid id) : base(request.TableIds,request.RestaurantId ,request.BookingDate, request.NumberOfPeople, request.Note, request.BookingStatusId)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}