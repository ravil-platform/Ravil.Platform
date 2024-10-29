using RNX.Mediator;
using ViewModels.QueriesResponseViewModel.Job;

namespace Application.Features.Job.Queries.GetRelatedJobs
{
    public class GetRelatedJobsQuery : IRequest<List<JobViewModel>>
    {
        public int JobId { get; set; }
        public int Take { get; set; }
    }
}
