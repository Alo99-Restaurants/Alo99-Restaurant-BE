using BookingServices.Entities.Entities;
using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Model.RestaurantFloorModels;

namespace BookingServices.Model.RestaurantModels
{
    public class RestaurantDTO : EntityAudit<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public int TotalFloors { get; set; }

        public IEnumerable<RestaurantFloorDTO>? RestaurantFloors { get; set; }
        public IEnumerable<RestaurantImages> TableImages { get; set; }
    }
}
