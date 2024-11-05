namespace Application.Features.Job.Commands.UploadJobBranchGalleries
{
    public class UploadJobBranchGalleriesCommand : IRequest
    {
        public string JobBranchId { get; set; }
        public IFormFileCollection Images { get; set; }

    }
}
