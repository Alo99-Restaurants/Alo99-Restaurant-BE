using AutoMapper;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Core;
using BookingServices.Entities.Contexts;
using BookingServices.Model.TableModels;
using Microsoft.EntityFrameworkCore;
using BookingServices.Entities.Entities;

namespace BookingServices.Application.Services.Table;

public class TableServices : ITableServices
{

    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;

    public TableServices(BookingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task AddTableAsync(AddTableRequest table)
    {
        _context.Add(_mapper.Map<Tables>(table));
        await _context.SaveChangesAsync();
    }

    public Task DeleteTableAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiPaged<TableDTO>> GetAllTablesAsync(GetAllTableRequest request)
    {
        return new ApiPaged<TableDTO>
        {
            Items = _mapper.Map<IEnumerable<TableDTO>>(await _context.Tables.WhereIf(request.RestaurantFloorId != null, x => x.RestaurantFloorId == request.RestaurantFloorId).Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = await _context.Tables.WhereIf(request.RestaurantFloorId != null, x => x.RestaurantFloorId == request.RestaurantFloorId).CountAsync()
        };
    }

    public async Task<TableDTO> GetTableByIdAsync(Guid id) => _mapper.Map<TableDTO>(await _context.Tables.IgnoreQueryFilters().Include(x => x.Bookings.OrderByDescending(x=> x.BookingDate).Skip(0).Take(10)).FirstOrDefaultAsync(x => x.Id == id));

    public async Task UpdateTableAsync(UpdateTableRequest table)
    {
        //check exist
        var tableEntity = _context.Tables.Find(table.Id);
        if (tableEntity == null) throw new Exception("Table not found");

        _mapper.Map(table, tableEntity);
        _context.Update(tableEntity);
        await _context.SaveChangesAsync();
    }
}
