using BookingServices.Entities.Entities.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Entities.Entities
{
    public class Restaurants : EntityAudit<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string? Greetings { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0,5,ErrorMessage ="Range from 0 to 5")]
        public double? Rating { get; set; }
        public string? PhoneNumber { get; set; }
        public int Capacity { get; set; }
        public int TotalFloors { get; set; }

        public virtual ICollection<RestaurantFloors> RestaurantFloors { get; set; }
        public virtual ICollection<RestaurantImages> RestaurantImages { get; set; }
    }
}
