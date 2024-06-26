﻿namespace BookingServices.External.Model.VNPay;

public class OrderInfo
{
    public Guid OrderId { get; set; }
    public long Amount { get; set; }
    public string OrderDesc { get; set; }

    public DateTime CreatedDate { get; set; }
    public string Status { get; set; }

    public long PaymentTranId { get; set; }
    public string BankCode { get; set; }
    public string PayStatus { get; set; }


}