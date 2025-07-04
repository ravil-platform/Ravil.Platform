﻿using Common.Utilities.Extensions;

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
        Task<bool> DeleteFileToFtpServer(string originSavePath, string deleteFileName, string? thumbSavePath = null);
        #endregion
    }
}
