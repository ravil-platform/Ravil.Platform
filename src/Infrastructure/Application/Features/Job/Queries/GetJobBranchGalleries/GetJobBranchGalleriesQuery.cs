namespace Application.Features.Job.Queries.GetJobBranchGalleries
{
    public class GetJobBranchGalleriesQuery : IRequest<List<JobBranchGalleryViewModel>>
    {
        public string JobBranchId { get; set; } = null!;
    }
}
