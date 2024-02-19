using BookingServices.Core;
using BookingServices.External.Interfaces;
using BookingServices.External.Model.VNPay;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : MyControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IVnPayServices _vnPayServices;
        public OrderController(ILogger<OrderController> logger, IVnPayServices vnPayServices)
        {
            _logger = logger;
            _vnPayServices = vnPayServices;
        }

        //api tạo thanh toán
        [HttpPost("create-payment")]
        public IActionResult CreatePayment(OrderInfo order)
        {
            var paymentUrl = _vnPayServices.GetPaymentUrl(order, "https://localhost:7130/swagger/index.html");
            return ApiOk(paymentUrl);
        }
    }
}
