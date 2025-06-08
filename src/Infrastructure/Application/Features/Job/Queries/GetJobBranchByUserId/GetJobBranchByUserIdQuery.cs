namespace Application.Features.Job.Queries.GetJobBranchByUserId
{
    public class GetJobBranchByUserIdQuery : IRequest<JobBranchViewModel>
    {
        public string UserId { get; set; }
    }
}
