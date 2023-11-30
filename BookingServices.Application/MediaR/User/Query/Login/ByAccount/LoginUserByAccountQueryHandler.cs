using BookingServices.Entities.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Query.Login.ByAccount
{
    public class LoginUserByAccountQueryHandler : IRequestHandler<LoginUserByAccountQuery, string>
    {
        public readonly BookingDbContext _bookingDbContext;

        public LoginUserByAccountQueryHandler(BookingDbContext bookingDbContext)
        {
            _bookingDbContext = bookingDbContext;
        }

        public async Task<string> Handle(LoginUserByAccountQuery request, CancellationToken cancellationToken)
        {
            var user =await _bookingDbContext.Users.FirstOrDefaultAsync(x => x.Username == request.Username);
            if(user == null)
            {
                throw new Exception("User not found");
            }
            if(!Core.Utils.VerifyPassword(request.Password, user.Password)) throw new ClientException("Password is incorrect");


            return Core.Identity.JwtTokenGenerator.GenerateJwtToken("your_secret_key_test", user.Id.ToString(), "your_issuer", "your_audience", new List<string> { user.Role.ToString() });
        }
    }
}
