
namespace BookingServices.Model.MenuImageModels;

public class UpdateMenuImageRequest : AddMenuImageRequest
{
    public Guid Id { get; set; }
    public UpdateMenuImageRequest(AddMenuImageRequest request, Guid id) : base(request.MenuId, request.ImageUrl)
    {
        Id = id;
    }
}