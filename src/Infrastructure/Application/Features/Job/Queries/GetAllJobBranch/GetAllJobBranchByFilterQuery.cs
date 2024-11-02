
namespace Application.Features.Job.Queries.GetAllJobBranch
{
    public class GetAllJobBranchByFilterQuery : IRequest<JobBranchFilter>
    {
        public JobBranchFilter JobBranchFilter { get; set; }
    }
}