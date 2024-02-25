using BookingServices.Model.TableModels;

namespace BookingServices.Application.MediaR.Table.Command.Updates;

public class UpdatesTableCommand : IRequest<IEnumerable<TableDTO>>
{
    public Guid RestaurantFloorId { get; set; }

    public IEnumerable<UpdateTableRequest> Tables { get; set; }
}
