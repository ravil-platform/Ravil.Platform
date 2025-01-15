using Common.Utilities.Services.FTP;
using Common.Utilities.Services.FTP.Models;
using Microsoft.Extensions.Options;
namespace Admin.MVC.Controllers
{
    public class UploadController : Controller
    {
        private IOptions<FTPConnectionOptions> FtpConnectionOptions { get; }
        protected IFtpService FtpService { get; }

        public UploadController(IFtpService ftpService, IOptions<FTPConnectionOptions> ftpConnectionOptions)
        {
            FtpService = ftpService;
            FtpConnectionOptions = ftpConnectionOptions;
        }
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
