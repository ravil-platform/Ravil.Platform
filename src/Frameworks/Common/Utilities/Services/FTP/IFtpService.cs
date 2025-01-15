using System.IO;
using System.Security.Authentication;
using AngleSharp.Io;
using Azure;
using Common.Utilities.Extensions;
using Constants.Files;
using Microsoft.AspNetCore.Http;

namespace Common.Utilities.Services.FTP
{
    public interface IFtpService
    {
        #region ( Methods )
        void ConnectAsync();
        void DisconnectAsync();
        
        Task<bool> SetFtpConnection(string path);
        Task SetFilePermissions(string path, int permissions);
        Task<bool> DownloadFileFromFtpServer(Stream stream, string inputImagePath);
        Task<string> UploadFileToFtpServer(IFormFile file, TypeFile typeFile, string originSavePath, string originSaveFilename, int permissions = 777, int? resizeWidth = null, int? resizeHeight = null, string? thumbSavePath = null, string? deleteFileName = null);
        #endregion
    }
}
