using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Query.ResetPassword
{
    public class ResetPasswordQuery : IRequest<bool>
    {
        public string Email { get; set; }
        public string ClientUrl { get; set; }
    }
}
