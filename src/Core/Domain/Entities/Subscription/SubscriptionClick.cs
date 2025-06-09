namespace Domain.Entities.Subscription;

public class SubscriptionClick : BaseEntity
{
    public Guid Id { get; set; }
    
    public string KeywordPageTitle { get; set; }
    public string KeywordPageUrl { get; set; }
    public string KeywordSlug { get; set; }
    public Guid? KeywordId { get; set; }
    
    public DateTime ClickedTime { get; set; }
    public decimal CostPerClick { get; set; }
    public bool IsDeposit { get; set; }
    public int? Position { get; set; }


    public int JobId { get; set; }
    public virtual required Job.Job Job { get; set; }

    public int ClickId { get; set; }
    public virtual required Click Click { get; set; }

    public int SubscriptionId { get; set; }
    public virtual required Subscription Subscription { get; set; }
}