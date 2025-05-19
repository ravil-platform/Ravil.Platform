using Domain.Entities.Payment;

namespace ViewModels.AdminPanel.Filter;

public class PaymentFilterViewModel : Paging<Domain.Entities.Payment.Payment>
{
    public DateTime? From { get; set; }
    public DateTime? To { get; set; }
    
    public string? Number { get; set; }
    public string? UserId { get; set; }
    public int? PaymentPortalId { get; set; }
    public int? PromotionCodeId { get; set; }

    public bool FindAll { get; set; }
}