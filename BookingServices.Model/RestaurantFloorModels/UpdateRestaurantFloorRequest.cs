namespace BookingServices.Model.RestaurantFloorModels
{
    public class UpdateRestaurantFloorRequest : AddRestaurantFloorRequest
    {
        public int Id { get; set; }
        public UpdateRestaurantFloorRequest(AddRestaurantFloorRequest request, int id) : base(request.RestaurantId, request.Name, request.FloorNumber, request.Capacity, request.LayoutUrl,request.ExtensionData)
        {
            this.Id = id;
        }

    }
}
