using System.ComponentModel.DataAnnotations;

namespace BookingServices.Entities.Enum;

public enum EMenuType
{
    [Display(Name = "Món ăn")]
    Food = 1,
    [Display(Name = "Thức uống")]
    Drink = 2
}
