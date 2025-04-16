namespace Domain.Entities.Subscription;

public class UserSubscription : BaseEntity
{
    public int Id { get; set; }

    public int SubscriptionId { get; set; }
    public Subscription Subscription { get; set; }

    public string UserId { get; set; }
    public ApplicationUser User { get; set; }

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public int BuyCount { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Payment.Payment> Payments { get; set; }
}