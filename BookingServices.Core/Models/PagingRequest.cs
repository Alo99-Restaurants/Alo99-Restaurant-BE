namespace BookingServices.Core.Models;

public class PagingRequest
{
    public int TotalRows { get; set; } = 10;
    public int SkipRows { get; set; } = 0;
}