namespace Domain.Entities.Subscription;

public class Click : BaseEntity
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CostPerClick { get; set; }

    public ClickType Type { get; set; }

    public virtual ICollection<SubscriptionClick> SubscriptionClicks { get; set; }
}

