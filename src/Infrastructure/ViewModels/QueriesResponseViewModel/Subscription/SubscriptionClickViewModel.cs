namespace ViewModels.QueriesResponseViewModel.Subscription
{
    public class SubscriptionClickViewModel
    {
        public Guid Id { get; set; }
        
        public string KeywordPageTitle { get; set; } = null!;
        public string KeywordPageUrl { get; set; } = null!;
        public string KeywordSlug { get; set; } = null!;
        public Guid KeywordId { get; set; }

        public long ClickedTimeStamp { get; set; }
        public decimal CostPerClick { get; set; }
        public bool IsDeposit { get; set; }
        public int Position { get; set; }

        public int ClickId { get; set; }
        public ClickType ClickType { get; set; }
        public string ClickTitle { get; set; } = null!;

        public int SubscriptionId { get; set; }
    }
}
