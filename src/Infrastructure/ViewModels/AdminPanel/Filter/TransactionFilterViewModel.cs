using Domain.Entities.Wallets;

namespace ViewModels.AdminPanel.Filter;

public class TransactionFilterViewModel : Paging<Transaction>
{
    public string? RefId { get; set; }
    public string? AuthCode { get; set; }
    public string? TrackingCode { get; set; }

    public TransactionStatus? Status { get; set; }

    public DateTime? From { get; set; }
    public DateTime? To { get; set; }

    public bool FindAll { get; set; }
}