namespace Application.Features.Job.Queries.GetJobBranchTags
{
    public class GetJobBranchTagsByIdQuery : IRequest<List<JobBranchTagViewModel>>
    {
        public string JobBranchId { get; set; }
    }
}
