using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BookingServices.Application.MediaR.Restaurant.Command.Insert;

public class InsertRestaurantCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string Address { get; set; }

    [Range(1, 10, ErrorMessage = "Range 1 -> 10")]
    public int Capacity { get; set; }
    [Range(1, 81, ErrorMessage = "Range 1 -> 81")]
    public int TotalFloors { get; set; }
}
