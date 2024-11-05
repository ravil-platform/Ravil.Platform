namespace Application.Features.Job.Commands.UploadJobBranchImage
{
    public class UploadJobBranchImageCommand : IRequest
    {
        public string JobBranchId { get; set; }
        public IFormFile? PhoneImage { get; set; }
        public IFormFile? DesktopImage { get; set; }
    }
}
