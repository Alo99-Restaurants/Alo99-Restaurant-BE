using BookingServices.Application.Services.Table;
using BookingServices.Core;
using BookingServices.Model.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TableController : MyControllerBase
{
    private readonly ITableServices _tableServices;

    public TableController(ITableServices tableServices)
    {
        _tableServices = tableServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllTablesAsync()
    {
        return Ok(await _tableServices.GetAllTablesAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTableByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<IActionResult> AddTableAsync(AddTableRequest table)
    {
        throw new ClientException("lỗi tào lao");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTableAsync(UpdateTableRequest table)
    {
        await _tableServices.UpdateTableAsync(table);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTableAsync(int id)
    {
        await _tableServices.DeleteTableAsync(id);
        return Ok();
    }
}
