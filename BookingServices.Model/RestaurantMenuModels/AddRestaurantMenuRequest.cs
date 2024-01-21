using BookingServices.Entities.Enum;

namespace BookingServices.Model.RestaurantMenuModels;

public class AddRestaurantMenuRequest
{
    public AddRestaurantMenuRequest(string name, string description, EMenuType menuType, EUnitType unitType, decimal price)
    {
        Name = name;
        Description = description;
        MenuType = menuType;
        UnitType = unitType;
        Price = price;
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public EMenuType MenuType { get; set; }
    public EUnitType UnitType { get; set; }
    public decimal Price { get; set; }
}