namespace BookingServices.Model.RestaurantFloorModels;

public class AddRestaurantFloorRequest
{
    public int RestaurantId { get; set; }
    public string Name { get; set; }
    public int FloorNumber { get; set; }
    public int Capacity { get; set; }
    public string? LayoutUrl { get; set; }
    public string? ExtensionData { get; set; }

    //ctor foreach
    public AddRestaurantFloorRequest(int restaurantId, string name, int floorNumber, int capacity, string? layoutUrl, string? extensionData)
    {
        RestaurantId = restaurantId;
        Name = name;
        FloorNumber = floorNumber;
        Capacity = capacity;
        LayoutUrl = layoutUrl;
        ExtensionData = extensionData;
    }
}
