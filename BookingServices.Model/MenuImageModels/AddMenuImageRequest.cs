namespace BookingServices.Model.MenuImageModels;

public class AddMenuImageRequest
{
    public AddMenuImageRequest(Guid menuId, string imageUrl)
    {
        MenuId = menuId;
        ImageUrl = imageUrl;
    }

    public Guid MenuId { get; set; }
    public string ImageUrl { get; set; }
}