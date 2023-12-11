namespace BookingServices.Model.RestaurantFloorModels;

public class UpdateRestaurantFloorRequest(AddRestaurantFloorRequest request, int id) : AddRestaurantFloorRequest(request.RestaurantId, request.Name, request.FloorNumber, request.Capacity, request.LayoutUrl, request.ExtensionData)
{
    public int Id { get; set; } = id;
}
