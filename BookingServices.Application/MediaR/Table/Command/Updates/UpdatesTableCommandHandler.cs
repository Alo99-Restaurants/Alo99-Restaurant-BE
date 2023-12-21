using AutoMapper;
using BookingServices.Application.Services.Table;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.TableModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Table.Command.Updates
{
    public class UpdatesTableCommandHandler : IRequestHandler<UpdatesTableCommand, IEnumerable<TableDTO>>
    {
        private readonly BookingDbContext _bookingDbContext;
        private readonly IMapper _mapper;
        private readonly ITableServices _tableServices;

        public UpdatesTableCommandHandler(BookingDbContext bookingDbContext, IMapper mapper, ITableServices tableServices)
        {
            _bookingDbContext = bookingDbContext;
            _mapper = mapper;
            _tableServices = tableServices;
        }

        public async Task<IEnumerable<TableDTO>> Handle(UpdatesTableCommand request, CancellationToken cancellationToken)
        {
            if(request.Tables.Any(x=> x.RestaurantFloorId != request.RestaurantFloorId)) throw new ClientException ("Dữ liệu không hợp lệ");

            var tables =await _bookingDbContext.Tables.Where(x => x.RestaurantFloorId == request.RestaurantFloorId).ToListAsync();

            //get table not in request.tables
            var deleteTable = tables.Where(x => !request.Tables.Select(s => s.Id).ToList().Contains(x.Id));

            //update if exist else add
            foreach (var table in request.Tables)
            {
                var tableEntity = tables.FirstOrDefault(x => x.Id == table.Id);
                if (tableEntity != null)
                {
                    _mapper.Map(table, tableEntity);
                    _bookingDbContext.Update(tableEntity);
                }
                else
                {
                    var newTable = _mapper.Map<Tables>(table);
                    _bookingDbContext.Add(newTable);
                }
            }
            
            
            //delete table
            _bookingDbContext.RemoveRange(deleteTable);
            _bookingDbContext.SaveChanges();

            var rs = _bookingDbContext.Tables.Where(x => x.RestaurantFloorId == request.RestaurantFloorId).ToList();
            return _mapper.Map<IEnumerable<TableDTO>>(rs);


        }
    }
}
