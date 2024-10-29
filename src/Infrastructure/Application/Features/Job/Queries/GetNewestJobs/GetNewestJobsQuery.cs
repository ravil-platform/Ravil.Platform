using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.Features.Job.Queries.GetNewestJobs
{
    public class GetNewestJobsQuery : IRequest<List<JobViewModel>>
    {
        public int Take { get; set; }
    }
}
