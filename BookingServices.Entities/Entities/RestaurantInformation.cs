

using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Entities.Entities;

public class RestaurantInformation : EntityAudit<int>
{
    public string RestaurantName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Website { get; set; }
    public string? Email { get; set; }
    public TimeOnly OpenTime { get; set; }
    public TimeOnly CloseTime { get; set; }
    public string? ExtensionData { get; set; }
}
