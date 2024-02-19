using BookingServices.Entities.Enum;

namespace BookingServices.Model.RestaurantMenuModels;

public class AddRestaurantMenuRequest
{
    public AddRestaurantMenuRequest(string name, string description, Guid menuCategoryId, EUnitType unitType, decimal price, string menuUrl)
    {
        Name = name;
        Description = description;
        MenuCategoryId = menuCategoryId;
        UnitType = unitType;
        Price = price;
        MenuUrl = menuUrl;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string MenuUrl { get; set; }
    public Guid MenuCategoryId { get; set; }
    public EUnitType UnitType { get; set; }
    public decimal Price { get; set; }
}