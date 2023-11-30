using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Entities.Entities
{
    public class Bookings : EntityAudit<Guid>, IHaveDeleted
    {
        public int TableId { get; set; }
        public int BookingStatusId { get; set; }
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
        public bool IsDeleted { get; set; }
    }
}
