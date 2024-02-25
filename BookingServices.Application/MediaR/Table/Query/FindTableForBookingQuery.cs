using BookingServices.Model.TableModels;

namespace BookingServices.Application.MediaR.Table.Query;

public class FindTableForBookingQuery : IRequest<List<TableDTO>>
{
    public Guid? RestaurantId { get; set; }
    public int Capacity { get; set; }
    public DateTime BookingDate { get; set; }
}
