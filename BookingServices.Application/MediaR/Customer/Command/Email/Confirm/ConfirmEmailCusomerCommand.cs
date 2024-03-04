using BookingServices.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.Application.MediaR.Customer.Command.Email.Confirm
{
    public class ConfirmEmailCusomerCommand : IRequest<bool>
    {
        public string Email { get; set; }
        public Guid Id { get; set; }
        public string Checksum { get; set; }

        private string GetHashData()
        {
            return Email+Id;
        }

        public bool CheckSumValue()
        {
            return Utils.VerifyPassword(GetHashData(), Checksum);
        }
    }
}
