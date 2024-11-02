namespace Application.Features.Job.Queries.GetJobBranchById
{
    public class GetJobBranchByIdQuery : IRequest<JobBranchViewModel>
    {
        public string Id { get; set; }
    }
}
