using BookingServices.Entities.Entities.Interfaces;

namespace BookingServices.Entities.Entities;

public class Transaction : EntityAudit<Guid>,IHaveDeleted
{
    public double Amount { get; set; }
    public string BankCode { get; set; }
    public string? BankTranNo { get; set; }
    public string? CardType { get; set; }
    public string? PayDate { get; set; }
    public string OrderInfo { get; set; }
    public long TransactionNo { get; set; }
    public string ResponseCode { get; set; }
    public string TransactionStatus { get; set; }
    public string TxnRef { get; set; }
    public string? SecureHashType { get; set; }
    public string SecureHash { get; set; }
    public bool IsDeleted { get ; set ; }
}
