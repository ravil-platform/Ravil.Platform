using Application.Features.Job.Queries.GetJobBranchById;

namespace Application.Features.Job.Queries.GetJobBranchByRoute
{
    public class GetJobBranchByRouteQuery : IRequest<JobBranchViewModel>
    {
        public string Route { get; set; } = null!;
    }
}
