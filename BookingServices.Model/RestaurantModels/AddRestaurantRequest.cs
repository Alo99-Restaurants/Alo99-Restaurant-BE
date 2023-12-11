using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.RestaurantModels;

public class AddRestaurantRequest(string name, string address, int capacity, int totalFloors, string location, string? greetings, string? phoneNumber, string? closeHours, string? openHours)
{
    public string Name { get; set; } = name;
    public string Address { get; set; } = address;
    public string Location { get; set; } = location;
    public string? Greetings { get; set; } = greetings;
    public string? OpenHours { get; set; } = openHours;
    public string? CloseHours { get; set; } = closeHours;
    public string? PhoneNumber { get; set; } = phoneNumber;
    [Range(1, 10, ErrorMessage = "Range 1 -> 10")]
    public int Capacity { get; set; } = capacity;
    [Range(1, 81, ErrorMessage = "Range 1 -> 81")]
    public int TotalFloors { get; set; } = totalFloors;
}
