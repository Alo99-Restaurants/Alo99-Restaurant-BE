using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Entities.Entities
{
    public class Restaurants : EntityAudit<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int TotalFloors { get; set; }

        public virtual ICollection<RestaurantFloors> RestaurantFloors { get; set; }
        public virtual ICollection<RestaurantImages> TableImages { get; set; }
    }
}
