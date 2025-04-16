namespace Domain.Entities.Subscription;

public class SubscriptionClick : BaseEntity
{
    public Guid Id { get; set; }

    public int ClickId { get; set; }
    public required Click Click { get; set; }


    public int SubscriptionId { get; set; }
    public required Subscription Subscription { get; set; }

    public DateTime ClickedTime { get; set; }
}