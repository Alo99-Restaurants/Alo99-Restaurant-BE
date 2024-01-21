using System.ComponentModel.DataAnnotations;

namespace BookingServices.Entities.Enum;

public enum EUnitType
{
    [Display(Name = "Ly")]
    Glass = 1,
    [Display(Name = "Chai")]
    Bottle = 2,
    [Display(Name = "Lon")]
    Can = 3,
    [Display(Name = "Đĩa")]
    Plate = 4,
    [Display(Name = "Tô")]
    Bowl = 5,
    [Display(Name = "Đĩa")]
    Dish = 6,
    [Display(Name = "Cốc")]
    Cup = 7,
    [Display(Name = "Bát")]
    Pot = 8,
    [Display(Name = "Phần")]
    Portion = 9,
    [Display(Name = "Đĩa")]
    Saucer = 10,
    [Display(Name = "Bình")]
    Jug = 11,
    [Display(Name = "Bộ")]
    Set = 12
}
