namespace Application.Features.Job.Commands.RemoveJobBranchGalleries
{
    public class RemoveJobBranchGalleriesCommand : IRequest
    {
        public int GalleryImageId { get; set; }
        public string? JobBranchId { get; set; } = null!;
    }
}