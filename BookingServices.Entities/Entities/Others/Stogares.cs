using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Entities.Entities.Others;

public class Storages : EntityAudit<Guid>
{
    public string Name { get; set; }
    public string Url { get; set; }
}
