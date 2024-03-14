using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.External.Model.VNPay.Response
{
    public class IPNResponse
    {
        public string RspCode { get; set; }
        public string Message { get; set; }
    }
}
