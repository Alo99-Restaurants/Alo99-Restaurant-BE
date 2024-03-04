using AutoMapper;
using BookingServices.Core;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Entities;
using BookingServices.Entities.Enum;
using BookingServices.External.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Command
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly BookingDbContext _context;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public RegisterUserCommandHandler(BookingDbContext context, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
        }

        public Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            Customers newCustomer = null;
            if (request.Role == ERole.Customer)
            {
                //check role is customer then must have phonenumber and email
                if (string.IsNullOrEmpty(request.PhoneNumber) || string.IsNullOrWhiteSpace(request.Email))
                {
                    throw new ClientException("Phone number and Email is required for customer role");
                }
                if(_context.Customers.Any(x => x.PhoneNumber == request.PhoneNumber || (x.Email != null && x.Email == request.Email)))
                {
                    throw new ClientException("Phone number is exist");
                }
                newCustomer = new Customers
                {
                    PhoneNumber = request.PhoneNumber,
                    Name = request.Name,
                    Email = request.Email??"",
                    EmailConfirmed = false
                };
                _context.Customers.Add(newCustomer);
            }

            var user = _mapper.Map<Users>(request);
            user.CustomerId = newCustomer?.Id;
            _context.Users.Add(user);
            _context.SaveChanges();
            //check role is customer then have mail
            if (request.Role == ERole.Customer && !string.IsNullOrEmpty(request.Email))
            {
                var hashData = Utils.HashPassword($"{request.Email}{user.Id}");
                //var body = $@"<a href=""{request.ClientUrl}?email={request.Email}&id={user.Id}&checksum={Utils.HashPassword(request.Email+user.Id)}"">Click here to confirm your email</a>";
                //_emailService.SendEmailAsync(request.Email, "Welcome to Alo99-Restaurant", body);

                return Task.FromResult($"{request.ClientUrl}?email={request.Email}&id={user.Id}&checksum={hashData}");
            }
            
            return Task.FromResult("true");
        }
    }
}
