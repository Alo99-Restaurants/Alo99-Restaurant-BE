using System.ComponentModel;

namespace BookingServices.Entities.Enum;

public enum EGender
{
    [Description("Nam")]
    Male = 1,
    [Description("Nữ")]
    Female = 2,
    [Description("Khác")]
    Other = 3
}
