
namespace BookingServices.Application.Services.RestaurantImage;

public class UpdateRestaurantImageRequest : AddRestaurantImageRequest
{
    public Guid Id { get; set; }
    public UpdateRestaurantImageRequest(AddRestaurantImageRequest request, Guid id) : base(request.Name, request.Description, request.Url, request.RestaurantId)
    {
        Id = id;
    }
}