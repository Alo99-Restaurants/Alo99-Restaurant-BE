using BookingServices.Model.TableModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Table.Command.Updates;

public class UpdatesTableCommand : IRequest<IEnumerable<TableDTO>>
{
    public Guid RestaurantFloorId { get; set; }

    public IEnumerable<UpdateTableRequest> Tables { get; set; }
}
