namespace ViewModels.QueriesResponseViewModel.Subscription;

public class UserSubscriptionViewModel
{
    public int Id { get; set; }
    public SubscriptionViewModel Subscription { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int BuyCount { get; set; }
    public bool IsActive { get; set; }
}