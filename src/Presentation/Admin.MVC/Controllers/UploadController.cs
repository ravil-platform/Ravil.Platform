
namespace Admin.MVC.Controllers
{
    public class UploadController(IFtpService ftpService, IOptions<FTPConnectionOptions> ftpConnectionOptions)
        : Controller
    {
        private IOptions<FTPConnectionOptions> FtpConnectionOptions { get; } = ftpConnectionOptions;
        protected IFtpService FtpService { get; } = ftpService;

        [HttpPost]
        [Route("/UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile upload)
        {
            if (upload == null)
            {
                return BadRequest();
            }

            string imageName = await FtpService.UploadFileToFtpServer(upload, TypeFile.Image, Paths.CkeditorContent, upload.FileName);
            string url = FtpConnectionOptions.Value.UrlBase + Paths.CkeditorContent;

            return Json(new { Uploaded = true, url = url + imageName });
        }
    }
}
