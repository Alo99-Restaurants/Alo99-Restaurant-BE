using BookingServices.Model.TableModels;

namespace BookingServices.Application.Services.Table;

public interface ITableServices
{
    Task AddTableAsync(AddTableRequest table);
    Task UpdateTableAsync(UpdateTableRequest table);
    Task DeleteTableAsync(int id);
    Task<IEnumerable<TableDTO>> GetAllTablesAsync();
    Task<TableDTO> GetTableByIdAsync(int id);
}