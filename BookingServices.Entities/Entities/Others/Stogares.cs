using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Entities.Entities.Others;

public class Stogares : EntityAudit<Guid>
{
    public string Name { get; set; }
    public string Url { get; set; }
}
