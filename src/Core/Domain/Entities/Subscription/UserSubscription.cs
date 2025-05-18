namespace Domain.Entities.Subscription;

public class UserSubscription : BaseEntity
{
    public int Id { get; set; }

    public int SubscriptionId { get; set; }
    public virtual Subscription Subscription { get; set; }

    public string UserId { get; set; }
    public virtual ApplicationUser User { get; set; }

    public DateTime? RenewalDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public int BuyCount { get; set; }

    public bool IsActive { get; set; }
    public bool IsFinally { get; set; }

    public virtual Payment.Payment Payment { get; set; }
}