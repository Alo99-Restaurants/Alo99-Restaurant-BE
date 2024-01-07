namespace BookingServices.Model.RestaurantFloorModels;

public class AddRestaurantFloorRequest(Guid restaurantId, string name, int floorNumber, int capacity, string? layoutUrl, string? extensionData)
{
    public Guid RestaurantId { get; set; } = restaurantId;
    public string Name { get; set; } = name;
    public int FloorNumber { get; set; } = floorNumber;
    public int Capacity { get; set; } = capacity;
    public string? LayoutUrl { get; set; } = layoutUrl;
    public string? ExtensionData { get; set; } = extensionData;
}
