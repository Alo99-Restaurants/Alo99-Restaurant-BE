using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Query.Login.ByAccount
{
    public class LoginUserByAccountQuery : IRequest<string>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
