﻿using BookingServices.External.Model.VNPay;
using BookingServices.External.Model.VNPay.Request;

namespace BookingServices.External.Interfaces;

public interface IVnPayServices
{
    //get url thanh toán
    string GetPaymentUrl(OrderInfo order,string returnUrl);

    //xác thực chữ ký
    bool ValidateSignature(IPNRequest request);
}
