namespace BookingServices.Model.BookingMenuModels;

public class AddBookingMenuRequest
{
    public AddBookingMenuRequest(double quantity, string? specialRequest)
    {
        Quantity = quantity;
        SpecialRequest = specialRequest;
    }

    public double Quantity { get; set; }
    public string? SpecialRequest { get; set; }
    public Guid BookingId { get; set; }
    public Guid MenuId { get; set; }
}