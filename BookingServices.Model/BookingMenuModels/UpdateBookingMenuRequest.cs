namespace BookingServices.Model.BookingMenuModels;

public class UpdateBookingMenuRequest : UpdateBookingBody
{
    public Guid Id { get; set; }
    public UpdateBookingMenuRequest(UpdateBookingBody request, Guid id ) : base(request.Quantity,request.Price, request.SpecialRequest)
    {
        Id = id;
    }
}

public class UpdateBookingBody
{
    public double Quantity { get; set; }
    public double Price { get; set; }
    public string? SpecialRequest { get; set; }
    public UpdateBookingBody(double quantity, double price, string? specialRequest)
    {
        Quantity = quantity;
        SpecialRequest = specialRequest;
        Price = price;
    }
}