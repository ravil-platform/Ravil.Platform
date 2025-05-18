using ViewModels.QueriesResponseViewModel.Analytics;

namespace Application.Features.Job.Queries.GetJobViews;

public class GetJobViewsQuery : IRequest<JobViewsViewModel>
{
    public int JobId { get; set; }
}