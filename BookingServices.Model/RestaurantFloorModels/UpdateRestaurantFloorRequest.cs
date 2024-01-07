namespace BookingServices.Model.RestaurantFloorModels;

public class UpdateRestaurantFloorRequest(AddRestaurantFloorRequest request, Guid id) : AddRestaurantFloorRequest(request.RestaurantId, request.Name, request.FloorNumber, request.Capacity, request.LayoutUrl, request.ExtensionData)
{
    public Guid Id { get; set; } = id;
}
