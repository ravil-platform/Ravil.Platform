namespace Application.Features.Job.Commands.UploadJobBranchVideo
{
    public class UploadJobBranchVideoCommand : IRequest
    {
        public string JobBranchId { get; set; }
        public IFormFile Video { get; set; }
    }
}
