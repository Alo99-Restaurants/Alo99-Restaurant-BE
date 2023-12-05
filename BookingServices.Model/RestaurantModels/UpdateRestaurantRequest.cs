namespace BookingServices.Model.RestaurantModels;

public class UpdateRestaurantRequest : AddRestaurantRequest
{
    public int Id { get; set; }
    public UpdateRestaurantRequest(AddRestaurantRequest request, int id) : base(request.Name, request.Address, request.Capacity, request.TotalFloors, request.Location, request.Greetings, request.PhoneNumber) => this.Id = id;

}
