using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.User.Command.ResetPassword
{
    public class ResetPasswordCommand : IRequest<bool>
    {
        public string Id { get; set; }
        public string Checksum { get; set; }
        public string? NewPassword { get; set; } 
    }
}
