using BookingServices.Application.Services.RestaurantImage;
using BookingServices.Entities.Entities;
using BookingServices.Entities.Entities.Interfaces;
using BookingServices.Model.RestaurantFloorModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingServices.Model.RestaurantModels;

public class RestaurantDTO : IEntityAudit<Guid>
{
    //implement interface IentityAudit
    public Guid Id { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
    public string Location { get; set; }
    public string? Greetings { get; set; }
    public string? OpenHours { get; set; }
    public string? CloseHours { get; set; }
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, 5, ErrorMessage = "Range from 0 to 5")]
    public double Rating { get; set; }
    public string? PhoneNumber { get; set; }
    public int Capacity { get; set; }
    public int TotalFloors { get; set; }

    public Guid CreatedBy { get; set; }
    public DateTime CreatedDate { get; set; }
    public Guid? ModifiedBy { get; set; }
    public DateTime? ModifiedDate { get; set; }

    public IEnumerable<RestaurantFloorDTO>? RestaurantFloors { get; set; }
    public IEnumerable<RestaurantImageDTO>? RestaurantImages { get; set; }
}
