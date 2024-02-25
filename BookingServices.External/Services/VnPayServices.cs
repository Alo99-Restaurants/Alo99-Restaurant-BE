using BookingServices.External.Interfaces;
using BookingServices.External.Libraries;
using BookingServices.External.Model.VNPay;
using BookingServices.External.Model.VNPay.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using static AppConfigurations;

namespace BookingServices.External.Services;

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

    public bool ValidateSignature(IPNResponse response)
    {
        VnPayLibrary vnpay = new VnPayLibrary();
        vnpay.AddResponseData("vnp_TmnCode", response.vnp_TmnCode);
        vnpay.AddResponseData("vnp_Amount", response.vnp_Amount);
        vnpay.AddResponseData("vnp_BankCode", response.vnp_BankCode);
        vnpay.AddResponseData("vnp_BankTranNo", response.vnp_BankTranNo);
        vnpay.AddResponseData("vnp_CardType", response.vnp_CardType);
        vnpay.AddResponseData("vnp_PayDate", response.vnp_PayDate);
        vnpay.AddResponseData("vnp_OrderInfo", response.vnp_OrderInfo);
        vnpay.AddResponseData("vnp_TransactionNo", response.vnp_TransactionNo);
        vnpay.AddResponseData("vnp_ResponseCode", response.vnp_ResponseCode);
        vnpay.AddResponseData("vnp_TransactionStatus", response.vnp_TransactionStatus);
        vnpay.AddResponseData("vnp_TxnRef", response.vnp_TxnRef);
        

        //long orderId = Convert.ToInt64(vnpay.GetResponseData("vnp_TxnRef"));
        //long vnp_Amount = Convert.ToInt64(vnpay.GetResponseData("vnp_Amount")) / 100;
        //long vnpayTranId = Convert.ToInt64(vnpay.GetResponseData("vnp_TransactionNo"));
        //string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
        //string vnp_TransactionStatus = vnpay.GetResponseData("vnp_TransactionStatus");

        return vnpay.ValidateSignature(response.vnp_SecureHash, _vnPayConfigs.VnpHashSecret);
    }
}
