namespace BookingServices.Model.BookingMenuModels;

public class UpdateBookingMenuRequest : UpdateBookingBody
{
    public Guid Id { get; set; }
    public UpdateBookingMenuRequest(UpdateBookingBody request, Guid id ) : base(request.Quantity, request.SpecialRequest)
    {
        Id = id;
    }
}

public class UpdateBookingBody
{
    public double Quantity { get; set; }
    public string? SpecialRequest { get; set; }
    public UpdateBookingBody(double quantity, string? specialRequest)
    {
        Quantity = quantity;
        SpecialRequest = specialRequest;
    }
}