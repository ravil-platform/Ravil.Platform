namespace Application.Features.Job.Queries.GetBestJobs
{
    public class GetBestJobsQuery : IRequest<List<JobViewModel>>
    {
        public int Take { get; set; }
    }
}
