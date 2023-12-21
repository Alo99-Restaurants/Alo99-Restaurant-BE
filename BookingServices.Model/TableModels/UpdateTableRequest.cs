namespace BookingServices.Model.TableModels;

public class UpdateTableRequest : AddTableRequest
{
    public Guid? Id { get; set; }
    public UpdateTableRequest(AddTableRequest request,Guid id) : base(request.RestaurantFloorId, request.TableName, request.TableType, request.Capacity, request.ExtensionData)
    {
        Id = id;
    }
    public UpdateTableRequest()
    {
    }
}