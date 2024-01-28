using BookingServices.External.Model.VNPay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingServices.External.Interfaces
{
    public interface IVnPayServices
    {
        //get url thanh toán
        string GetPaymentUrl(OrderInfo order,string returnUrl);
    }
}
