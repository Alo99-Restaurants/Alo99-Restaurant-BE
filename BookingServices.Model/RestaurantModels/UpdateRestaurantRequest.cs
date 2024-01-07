namespace BookingServices.Model.RestaurantModels;

public class UpdateRestaurantRequest(AddRestaurantRequest request, Guid id) : AddRestaurantRequest(request.Name, request.Address, request.Capacity, request.TotalFloors, request.Location, request.Greetings, request.PhoneNumber, request.CloseHours, request.OpenHours)
{
    public Guid Id { get; set; } = id;
}
