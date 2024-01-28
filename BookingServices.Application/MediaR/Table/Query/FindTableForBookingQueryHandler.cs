using AutoMapper;
using BookingServices.Application.Services.Table;
using BookingServices.Core;
using BookingServices.Entities.Contexts;
using BookingServices.Model.TableModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Table.Query
{
    public class FindTableForBookingQueryHandler : IRequestHandler<FindTableForBookingQuery,IEnumerable<TableDTO>>
    {
        private readonly BookingDbContext _dbContext;
        private readonly IMapper _mapper;

        public FindTableForBookingQueryHandler(BookingDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TableDTO>> Handle(FindTableForBookingQuery request, CancellationToken cancellationToken)
        {
            var tables = _dbContext.RestaurantFloors.WhereIf(request.RestaurantId != null,x => x.RestaurantId == request.RestaurantId)
                .SelectMany(x => x.Tables)
                .Where(x => x.Capacity >= request.Capacity)
                .Include(x=> x.Bookings.Where(x=> x.BookingDate.Date == request.BookingDate.Date).Take(1))
                .ToList();
            
            return _mapper.Map<IEnumerable<TableDTO>>(tables);
        }
    }
}
