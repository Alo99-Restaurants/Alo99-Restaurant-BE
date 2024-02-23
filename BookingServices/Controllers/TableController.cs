using BookingServices.Application.MediaR.Table.Command.Updates;
using BookingServices.Application.MediaR.Table.Query;
using BookingServices.Application.Services.Table;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.TableModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TableController : MyControllerBase
{

    private readonly ITableServices _tableServices;
    private readonly IMediator _mediator;

    public TableController(ITableServices tableServices, IMediator mediator)
    {
        _tableServices = tableServices;
        _mediator = mediator;
    }

    //getall
    [HttpGet("")]
    [ProducesResponseType(typeof(ApiPaged<TableDTO>), 200)]
    public async Task<IActionResult> GetAllTables([FromQuery] GetAllTableRequest request) => ApiOk(await _tableServices.GetAllTablesAsync(request));

    //get by id
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<TableDTO>), 200)]
    public async Task<IActionResult> GetTable(Guid id) => ApiOk(await _tableServices.GetTableByIdAsync(id));

    //add
    [HttpPost]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddTable(AddTableRequest table)
    {
        await _tableServices.AddTableAsync(table);
        return ApiOk();
    }

    //update
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateTable(Guid id, AddTableRequest table)
    {
        await _tableServices.UpdateTableAsync(new UpdateTableRequest(table, id));
        return ApiOk();
    }

    //UpdatesTableCommand implement api
    [HttpPut("updates")]
    [ProducesResponseType(typeof(ApiResult<IEnumerable<TableDTO>>), 200)]
    public async Task<IActionResult> UpdateTables(UpdatesTableCommand command)
    {
        var rs = await _mediator.Send(command);
        return ApiOk(rs);
    }

    //FindTableForBookingQuery implement api
    [HttpPost("find")]
    [ProducesResponseType(typeof(ApiResult<List<TableDTO>>), 200)]
    public async Task<IActionResult> FindTableForBooking([FromBody] FindTableForBookingQuery query)
    {
        var rs = await _mediator.Send(query);
        return ApiOk(rs);
    }
}
