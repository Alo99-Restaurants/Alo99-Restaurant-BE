namespace BookingServices.Model.MenuCategoryModels
{
    public class UpdateMenuCategoryRequest : AddMenuCategoryRequest
    {
        public UpdateMenuCategoryRequest(AddMenuCategoryRequest request,Guid id) : base(request.Name, request.IconUrl)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}