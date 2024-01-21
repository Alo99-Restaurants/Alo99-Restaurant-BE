using AutoMapper;
using BookingServices.Core.Models.ControllerResponse;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Model.CustomerModels;
using Microsoft.EntityFrameworkCore;

namespace BookingServices.Application.Services.Customer;

public class CustomerServices : ICustomerServices
{
    private readonly BookingDbContext _context;
    private readonly IMapper _mapper;

    public CustomerServices(BookingDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CustomerDTO> AddCustomerAsync(AddCustomerRequest customer)
    {
        var addcustomer = _mapper.Map<Customers>(customer);
        //add customer
        _context.Add(addcustomer);
        //save changes
        await _context.SaveChangesAsync();
        return _mapper.Map<CustomerDTO>(addcustomer);
    }

    public async Task<ApiPaged<CustomerDTO>> GetAllCustomersAsync(GetAllCustomerRequest request)
    {
        //get all customers
        return new ApiPaged<CustomerDTO>
        {
            Items = _mapper.Map<IEnumerable<CustomerDTO>>(await _context.Customers.Skip(request.SkipRows).Take(request.TotalRows).ToListAsync()),
            TotalRecords = await _context.Customers.CountAsync()
        };
    }

    public async Task<CustomerDTO> GetCustomerByIdAsync(Guid id)
    {
        //get customer by id
        return _mapper.Map<CustomerDTO>(await _context.Customers.Include(x=> x.User).FirstOrDefaultAsync(x=> x.Id ==id));
    }

    public async Task UpdateCustomerAsync(UpdateCustomerRequest customer)
    {
        //get customer by id and check if null
        var customerEntity =await _context.Customers.FindAsync(customer.Id);
        if (customerEntity == null) throw new Exception("Customer not found");

        //map customer
        _mapper.Map(customer, customerEntity);

        //update customer
        _context.Update(customerEntity);
        //save changes
        _context.SaveChanges();
    }
}
