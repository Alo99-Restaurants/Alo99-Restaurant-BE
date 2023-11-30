using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities
{
    public class RestaurantFloors : EntityAudit<int>
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public int FloorNumber { get; set; }
        public int Capacity { get; set; }
        public string? LayoutUrl { get; set; }
        public string? ExtensionData { get; set; }


        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurants Restaurant { get; set; }

        public virtual ICollection<Tables> Tables { get; set; }
    }
}
