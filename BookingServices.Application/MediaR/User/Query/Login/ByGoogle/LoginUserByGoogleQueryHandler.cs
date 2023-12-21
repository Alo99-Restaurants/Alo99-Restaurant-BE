using AutoMapper;
using BookingServices.Application.Services.Customer;
using BookingServices.Application.Services.User;
using BookingServices.Entities.Contexts;
using BookingServices.Entities.Enum;
using BookingServices.Model.CustomerModels;
using BookingServices.Model.UserModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppConfigurations;

namespace BookingServices.Application.MediaR.User.Query.Login.ByGoogle
{
    public class LoginUserByGoogleQueryHandler : IRequestHandler<LoginUserByGoogleQuery, LoginResponseModel>
    {
        private readonly IMapper _mapper;
        private readonly BookingDbContext _bookingDbContext;
        private readonly JwtConfigurations _jwt;
        private readonly IUserServices _userServices;
        private readonly ICustomerServices _customerServices;

        public LoginUserByGoogleQueryHandler(IMapper mapper, BookingDbContext bookingDbContext, IOptions<JwtConfigurations> jwt, IUserServices userServices, ICustomerServices customerServices)
        {
            _mapper = mapper;
            _bookingDbContext = bookingDbContext;
            _jwt = jwt.Value;
            _userServices = userServices;
            _customerServices = customerServices;
        }

        public async Task<LoginResponseModel> Handle(LoginUserByGoogleQuery request, CancellationToken cancellationToken)
        {
            string token;
            
            var customer = await _bookingDbContext.Customers.Include(x=> x.User).FirstOrDefaultAsync(x => x.Email == request.Email);
            if(customer == null)
            {
                //add customer
                var newCustomer = await _customerServices.AddCustomerAsync(new AddCustomerRequest
                {
                    Name = request.Name,
                    Email = request.Email,
                });
               
                //add user
                var newUser = await _userServices.AddUser(new AddUserRequest
                {
                    Name = newCustomer.Name,
                    Username = request.Email,
                    Password = "adminbackdoor",
                    Role = ERole.Customer,
                    CustomerId = newCustomer.Id
                });
                //generate token
                token = Core.Identity.JwtTokenGenerator.GenerateJwtToken(_jwt.SecretKey, newUser.Id.ToString(), _jwt.Issuer, _jwt.Audience, new List<string> { newUser.Role.ToString() }, _jwt.ExpirationMinutes,
                    email: newCustomer.Email,fullName:newCustomer.Name);

                return new LoginResponseModel
                {
                    JwtToken = token,
                    UserInfor = newUser
                };
            }else if(customer.User == null)
            {
                //create user
                var newUser = await _userServices.AddUser(new AddUserRequest
                {
                    Username = request.Email,
                    Name = request.Name,
                    Password = "adminbackdoor",
                    Role = ERole.Customer,
                    CustomerId = customer.Id
                });
                //generate token
                token = Core.Identity.JwtTokenGenerator.GenerateJwtToken(_jwt.SecretKey, newUser.Id.ToString(), _jwt.Issuer, _jwt.Audience, new List<string> { newUser.Role.ToString() }, _jwt.ExpirationMinutes,
                                       email: customer.Email, fullName: customer.Name);
                return new LoginResponseModel
                {
                    JwtToken = token,
                    UserInfor = newUser
                };
            }
            else
            {
                //generate token
                token = Core.Identity.JwtTokenGenerator.GenerateJwtToken(_jwt.SecretKey, customer.User.Id.ToString(), _jwt.Issuer, _jwt.Audience, new List<string> { customer.User.Role.ToString() }, _jwt.ExpirationMinutes,
                                                          email: customer.Email, fullName: customer.Name);
                return new LoginResponseModel
                {
                    JwtToken = token,
                    UserInfor = _mapper.Map<UserDTO>(customer.User)
                };
            }
        }
    }
}
