using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities
{
    public class Tables : EntityAudit<int>
    {
        public int RestaurantFloorId { get; set; }
        public string TableName { get; set; }
        public int TableType { get; set; }
        public int Capacity { get; set; }
        public string ExtensionData { get; set; }

        [ForeignKey(nameof(RestaurantFloorId))]
        public virtual RestaurantFloors RestaurantFloor { get; set; }

    }
}
