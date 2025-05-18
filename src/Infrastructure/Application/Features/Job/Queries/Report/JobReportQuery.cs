using ViewModels.QueriesResponseViewModel.Subscription;

namespace Application.Features.Job.Queries.Report
{
    public class JobReportQuery : IRequest<List<SubscriptionClickViewModel>>
    {
        public int JobId { get; set; }
        public long? FromDate { get; set; }
        public long? ToDate { get; set; }
        public ClickType ClickType { get; set; } = ClickType.ClickOnAds;
    }
}
