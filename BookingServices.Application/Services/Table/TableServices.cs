using AutoMapper;
using BookingServices.Entities.Contexts;
using BookingServices.Model.TableModels;

namespace BookingServices.Application.Services.Table
{
    public class TableServices : ITableServices
    {

        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public TableServices(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task AddTableAsync(AddTableRequest table)
        {
            throw new NotImplementedException();
        }

        public Task DeleteTableAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TableDTO>> GetAllTablesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TableDTO> GetTableByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTableAsync(UpdateTableRequest table)
        {
            throw new NotImplementedException();
        }
    }
}
