using AutoMapper;
using BookingServices.Core;
using BookingServices.Entities.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Customer.Command.Email.Confirm
{
    public class ConfirmEmailCusomerCommandHandler : IRequestHandler<ConfirmEmailCusomerCommand, bool>
    {
        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;

        public ConfirmEmailCusomerCommandHandler(BookingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<bool> Handle(ConfirmEmailCusomerCommand request, CancellationToken cancellationToken)
        {
            //check checksum value 
            if(!request.CheckSumValue())
            {
                throw new ClientException("Invalid data");
            }
            //check user is exist
            var user = _context.Users.FirstOrDefault(x => x.Id == request.Id);
            if(user == null)
            {
                throw new ClientException("User is not exist");
            }
            //check email is confirmed
            var customer = _context.Customers.FirstOrDefault(x => x.Id == user.CustomerId);
            if(customer == null)
            {
                throw new ClientException("Customer is not exist");
            }
            if (string.IsNullOrEmpty(customer.Email) || !customer.EmailConfirmed)
            {
                customer.Email = request.Email;
                customer.EmailConfirmed = true;
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                throw new ClientException("Email is confirmed");
            }
        }
    }
}
