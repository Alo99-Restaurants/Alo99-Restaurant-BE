﻿using AutoMapper;
using BookingServices.Core;
using BookingServices.Entities.Contexts;
using BookingServices.Model.TableModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.MediaR.Table.Query;

public class FindTableForBookingQueryHandler : IRequestHandler<FindTableForBookingQuery,List<TableDTO>>
{
    private readonly BookingDbContext _dbContext;
    private readonly IMapper _mapper;

    public FindTableForBookingQueryHandler(BookingDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    public async Task<List<TableDTO>> Handle(FindTableForBookingQuery request, CancellationToken cancellationToken)
    {
        var tables = _dbContext.RestaurantFloors.WhereIf(request.RestaurantId != null,x => x.RestaurantId == request.RestaurantId)
            .SelectMany(x => x.Tables)
            .Include(x=> x.Bookings.Where(x=> x.BookingDate.Date == request.BookingDate.Date))
            .ToList();
        
        return _mapper.Map<List<TableDTO>>(tables);
    }
}
