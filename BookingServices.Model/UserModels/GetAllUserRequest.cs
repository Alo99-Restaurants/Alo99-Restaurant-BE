using BookingServices.Core.Models;

namespace BookingServices.Model.UserModels;

public class GetAllUserRequest : PagingRequest
{
    public string? SearchText { get; set; }
}
