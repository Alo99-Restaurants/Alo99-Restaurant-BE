namespace BookingServices.Model.RestaurantMenuModels;

public class UpdateRestaurantMenuRequest : AddRestaurantMenuRequest
{
    public Guid Id { get; set; }
    public UpdateRestaurantMenuRequest(Guid id, AddRestaurantMenuRequest request) : base(request.Name, request.Description, request.MenuType, request.UnitType, request.Price)
    {
        Id = id;
    }
}