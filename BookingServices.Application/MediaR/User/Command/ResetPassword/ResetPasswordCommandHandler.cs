using Amazon.S3.Model;
using AutoMapper;
using BookingServices.Core;
using BookingServices.Entities.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Command.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly BookingDbContext _context;

        public ResetPasswordCommandHandler(IMapper mapper, BookingDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public Task<bool> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            //check user
            var user = _context.Users.FirstOrDefault(x => x.Id == Guid.Parse(request.Id));
            if (user == null)
            {
                throw new ClientException("User not found");
            }

            //check customer
            var customer = _context.Customers.FirstOrDefault(x => x.Id == user.CustomerId);
            if (customer == null)
            {
                throw new ClientException("Customer not found");
            }

            var hashData = $"{customer.Email}{user.Id}{user.Password}";
            if (Utils.VerifyPassword(hashData, request.Checksum.Replace(" ", "+")))
            {

                user.Password = Utils.HashPassword(request.NewPassword ?? "123456789");
                _context.SaveChanges();
                return Task.FromResult(true);
            }
            else
            {
                throw new ClientException("Invalid data");
            }
        }
    }
}
