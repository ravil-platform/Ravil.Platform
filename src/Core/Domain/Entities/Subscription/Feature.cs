namespace Domain.Entities.Subscription;

public class Feature : BaseEntity
{
    public int Id { get; set; }
    public string? Icon { get; set; }
    public string Title { get; set; }

    public virtual ICollection<SubscriptionFeature> SubscriptionFeatures { get; set; }
}