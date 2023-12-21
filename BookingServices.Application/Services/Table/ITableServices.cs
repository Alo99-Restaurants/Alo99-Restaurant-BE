using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.TableModels;

namespace BookingServices.Application.Services.Table;

public interface ITableServices
{
    Task AddTableAsync(AddTableRequest table);
    Task UpdateTableAsync(UpdateTableRequest table);
    Task DeleteTableAsync(int id);
    Task<ApiPaged<TableDTO>> GetAllTablesAsync(GetAllTableRequest request);
    Task<TableDTO> GetTableByIdAsync(Guid id);
}