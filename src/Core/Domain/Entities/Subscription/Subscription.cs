namespace Domain.Entities.Subscription
{
    public class Subscription : BaseEntity
    {
        public int Id { get; set; }
        public string Icon { get; set; } = null!;

        public string Title { get; set; } = null!;
        public string SubTitle { get; set; } = null!;

        public int Price { get; set; }
        public int GiftCharge { get; set; }
        public short? Discount { get; set; }
        public double? DiscountAmount { get; set; }

        public int DurationTime { get; set; } // Ex:  30 Days
        
        public SubscriptionDurationType DurationType { get; set; }
        public SubscriptionType Type { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<SubscriptionFeature> SubscriptionFeatures { get; set; }
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
        public virtual ICollection<SubscriptionClick> SubscriptionClicks { get; set; }
    }
}
