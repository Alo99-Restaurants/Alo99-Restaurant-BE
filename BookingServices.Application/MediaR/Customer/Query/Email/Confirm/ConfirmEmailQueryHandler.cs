using AutoMapper;
using BookingServices.Core;
using BookingServices.Core.Identity;
using BookingServices.Entities.Contexts;
using BookingServices.External.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Customer.Query.Email.Confirm
{
    public class ConfirmEmailQueryHandler : IRequestHandler<ConfirmEmailQuery, bool>
    {
        private readonly IMapper _mapper;
        private readonly BookingDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ConfirmEmailQueryHandler(IMapper mapper, BookingDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            //get userid
            var userId = ClaimsPrincipalExtension.GetUserId(_httpContextAccessor.HttpContext?.User);
            //check user
            var user = _context.Users.Where(x => x.Id == userId).Include(x=> x.Customer).FirstOrDefault();
            if (user == null)
            {
                throw new ClientException("User is not exist");
            }

            //check customer
            //var customer = _context.Customers.FirstOrDefault(x => x.Id == user.CustomerId);
            if (user.Customer == null)
            {
                throw new ClientException("Customer is not exist");
            }
            if(user.Customer.EmailConfirmed)
            {
                throw new ClientException("Email already confirmed");
            }

            //check exist email in customer
            var existEmail = _context.Customers.FirstOrDefault(x => x.Email.Contains(request.Email) && x.Id != user.CustomerId);
            if (existEmail != null)
            {
                throw new ClientException("Email already exists");
            }

            var httpFormat = request.ClientUrl.StartsWith("http") ? '?' : '/';
            var hashData = Utils.HashPassword($"{request.Email}{user.Id}");
            var body = $@"<a href=""{request.ClientUrl}{httpFormat}email={request.Email}&id={user.Id}&checksum={hashData}"">Click here to confirm your email</a>";
            BackgroundJob.Enqueue<IEmailService>(x => x.SendEmailAsync(request.Email, "Welcome to Alo99-Restaurant", body));

            //return true
            return Task.FromResult(true);
        }
    }
}
