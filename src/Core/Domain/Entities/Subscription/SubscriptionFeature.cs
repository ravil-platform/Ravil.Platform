namespace Domain.Entities.Subscription;

public class SubscriptionFeature : BaseEntity
{
    public int Id { get; set; }

    public int SubscriptionId { get; set; }
    public virtual Subscription Subscription { get; set; }
    
    public int FeatureId { get; set; }
    public virtual Feature Feature { get; set; }
}