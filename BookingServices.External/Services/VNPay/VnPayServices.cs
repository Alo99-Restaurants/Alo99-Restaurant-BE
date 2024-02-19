using BookingServices.External.Interfaces;
using BookingServices.External.Libraries;
using BookingServices.External.Model.VNPay;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppConfigurations;

namespace BookingServices.External.Services.VNPay
{
    public class VnPayServices : IVnPayServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly VnPayConfigs _vnPayConfigs;

        public VnPayServices(IHttpContextAccessor httpContextAccessor, IOptions<VnPayConfigs> options)
        {
            _httpContextAccessor = httpContextAccessor;
            _vnPayConfigs = options.Value;
        }
        public string GetPaymentUrl(OrderInfo order, string returnUrl)
        {
            VnPayLibrary vnpay = new VnPayLibrary();
            vnpay.AddRequestData("vnp_Version", VnPayLibrary.VERSION);
            vnpay.AddRequestData("vnp_Command", "pay");
            vnpay.AddRequestData("vnp_TmnCode", _vnPayConfigs.VnpTmnCode);
            vnpay.AddRequestData("vnp_Amount", (order.Amount * 100).ToString());

            vnpay.AddRequestData("vnp_BankCode", order.BankCode);
            vnpay.AddRequestData("vnp_CreateDate", order.CreatedDate.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(_httpContextAccessor.HttpContext));
            vnpay.AddRequestData("vnp_Locale", "vn");

            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + order.OrderId);
            vnpay.AddRequestData("vnp_OrderType", "other");
            vnpay.AddRequestData("vnp_ReturnUrl", returnUrl);

            vnpay.AddRequestData("vnp_TxnRef", order.OrderId.ToString());

            string paymentUrl = vnpay.CreateRequestUrl(_vnPayConfigs.VnpUrl, _vnPayConfigs.VnpHashSecret);
            
            return paymentUrl;
        }
    }
}
