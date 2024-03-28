using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Identity;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Enum;
using BookingServices.External.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Query.ResetPassword
{
    public class ResetPasswordQueryHandler : IRequestHandler<ResetPasswordQuery, bool>
    {
        private readonly IMapper _mapper;
        private readonly BookingDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ResetPasswordQueryHandler(IMapper mapper, BookingDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> Handle(ResetPasswordQuery request, CancellationToken cancellationToken)
        {
            //check customer
            var customer = _context.Customers.FirstOrDefault(x => x.Email == request.Email);
            if (customer == null)
            {
                throw new ClientException("Customer not found");
            }
            if (!customer.EmailConfirmed) throw new ClientException("Email not confirm");

            var user = _context.Users.FirstOrDefault(x => x.CustomerId == customer.Id);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var httpFormat = request.ClientUrl.StartsWith("http") ? '?' : '/';
            var hashData = Utils.HashPassword($"{customer.Email}{user.Id}{user.Password}");
            var body = $@"<a href=""{request.ClientUrl}{httpFormat}id={user.Id}&checksum={hashData}"">Click here to reset your password</a>";

            BackgroundJob.Enqueue<IEmailService>(x => x.SendEmailAsync(customer.Email, "Alo99-Restaurant Reset Password", body));

            return Task.FromResult(true);
        }
    }
}
