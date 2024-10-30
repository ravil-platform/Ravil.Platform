namespace Application.Features.Job.Queries.GetJobBranchShortLinks
{
    public class GetJobBranchShortLinksQuery : IRequest<List<JobBranchShortLinkViewModel>>
    {
        public string JobBranchId { get; set; } = null!;
    }
}
