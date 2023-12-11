namespace BookingServices.Model.RestaurantModels;

public class UpdateRestaurantRequest(AddRestaurantRequest request, int id) : AddRestaurantRequest(request.Name, request.Address, request.Capacity, request.TotalFloors, request.Location, request.Greetings, request.PhoneNumber, request.CloseHours, request.OpenHours)
{
    public int Id { get; set; } = id;
}
