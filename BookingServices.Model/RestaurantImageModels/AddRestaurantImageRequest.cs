namespace BookingServices.Model.RestaurantImageModels;

public class AddRestaurantImageRequest
{
    public AddRestaurantImageRequest(string name, string description, string url, Guid restaurantId)
    {
        Name = name;
        Description = description;
        Url = url;
        RestaurantId = restaurantId;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Url { get; set; }
    public Guid RestaurantId { get; set; }
}