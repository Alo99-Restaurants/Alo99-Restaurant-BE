using System.ComponentModel.DataAnnotations;

namespace BookingServices.Model.RestaurantModels
{
    public class AddRestaurantRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string? Greetings { get; set; }
        public string? PhoneNumber { get; set; }
        [Range(1, 10, ErrorMessage = "Range 1 -> 10")]
        public int Capacity { get; set; }
        [Range(1, 81, ErrorMessage = "Range 1 -> 81")]
        public int TotalFloors { get; set; }

        //add ctor foreach properties
        public AddRestaurantRequest(string name, string address, int capacity, int totalFloors, string location, string? greetings, string? phoneNumber)
        {
            Name = name;
            Address = address;
            Capacity = capacity;
            TotalFloors = totalFloors;
            Location = location;
            Greetings = greetings;
            PhoneNumber = phoneNumber;
        }
    }
}
