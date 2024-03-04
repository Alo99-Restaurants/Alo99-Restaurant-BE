using BookingServices.Application.MediaR.Customer.Command.Email.Confirm;
using BookingServices.Application.Services.Customer;
using BookingServices.Core;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Model.CustomerModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : MyControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ICustomerServices _customerServices;
    private readonly IMediator _mediator;
   
    public CustomerController(ILogger<CustomerController> logger, ICustomerServices customerServices, IMediator mediator)
    {
        _logger = logger;
        _customerServices = customerServices;
        _mediator = mediator;
    }

    //getall
    [HttpGet("")]
    [Authorize(Roles = "Admin,Manager")]
    [ProducesResponseType(typeof(ApiPaged<CustomerDTO>), 200)]
    public async Task<IActionResult> GetAllCustomers([FromQuery] GetAllCustomerRequest request) => ApiOk(await _customerServices.GetAllCustomersAsync(request));

    //getbyid
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResult<CustomerDTO>), 200)]
    [Authorize(Roles = "Admin,Customer")]
    public async Task<IActionResult> GetCustomer(Guid id) => ApiOk(await _customerServices.GetCustomerByIdAsync(id));

    //add
    [HttpPost]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> AddCustomer(AddCustomerRequest customer)
    {
        await _customerServices.AddCustomerAsync(customer);
        return ApiOk();
    }

    //update
    [HttpPut("{id}")]
    [Authorize(Roles = "Admin,Customer")]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> UpdateCustomer(Guid id, AddCustomerRequest customer)
    {
        await _customerServices.UpdateCustomerAsync(new UpdateCustomerRequest(customer, id));
        return ApiOk();
    }

    //confirm email
    [HttpGet("confirm-email")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(ApiResult), 200)]
    public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCusomerCommand command)
    {
        await _mediator.Send(command);
        return ApiOk();
    }
}
