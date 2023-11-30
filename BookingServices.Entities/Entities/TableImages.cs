using BookingServices.Entities.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities
{
    public class RestaurantImages : EntityAudit<Guid>
    {
        public string Name { get; set; }
        [MaxLength()]
        public string Description { get; set; }
        public string Url { get; set; }
        public int RestaurantId { get; set; }

        [ForeignKey(nameof(RestaurantId))]
        public virtual Restaurants Restaurants { get; set; }
    }
}