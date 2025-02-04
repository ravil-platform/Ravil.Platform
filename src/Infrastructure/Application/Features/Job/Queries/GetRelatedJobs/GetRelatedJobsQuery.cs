namespace Application.Features.Job.Queries.GetRelatedJobs
{
    public class GetRelatedJobsQuery : IRequest<List<JobBranchViewModel>>
    {
        public int JobId { get; set; }
        public int Take { get; set; }
    }
}
