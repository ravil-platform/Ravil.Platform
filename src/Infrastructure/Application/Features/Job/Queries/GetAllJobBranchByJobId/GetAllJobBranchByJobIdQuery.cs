namespace Application.Features.Job.Queries.GetAllJobBranchByJobId
{
    public class GetAllJobBranchByJobIdQuery : IRequest<List<JobBranchViewModel>>
    {
        public int JobId { get; set; }
    }
}
