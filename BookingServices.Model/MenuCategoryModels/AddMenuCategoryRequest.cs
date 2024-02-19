namespace BookingServices.Model.MenuCategoryModels
{
    public class AddMenuCategoryRequest
    {
        public AddMenuCategoryRequest(string name, string iconUrl)
        {
            Name = name;
            IconUrl = iconUrl;
        }

        public string Name { get; set; }
        public string IconUrl { get; set; }
    }
}