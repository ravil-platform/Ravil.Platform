using System.Net;
using Common.Utilities.Extensions;
using Common.Utilities.Services.FTP.Models;
using FluentFTP;
using FluentFTP.Exceptions;
using Logging.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;

namespace Common.Utilities.Services.FTP;

public class FtpService : object, IFtpService
{
    #region ( Feildes )

    public int DefaultPermission = 777;
    public const string segmentSeperator = "\\";
    public const string segmentSeperatorSingle = "/";
    public static string rootDirectoryPath = string.Empty;
    public static string rootDirectory = $"public_html{segmentSeperator}";

    #endregion

    #region ( Properties )

    public FtpClient FtpClient { get; set; }
    public IConfiguration Configuration { get; }
    public FTPConnectionOptions FTPConnectionOptions { get; }
    private Logging.Base.ILogger<FtpService> Logger { get; }

    #endregion

    #region ( Constructor )

    public FtpService(IOptions<FTPConnectionOptions> options, IConfiguration configuration, ILogger<FtpService> logger)
    {
        Logger = logger;
        Configuration = configuration;
        FTPConnectionOptions = options.Value;

        FtpClient = new FluentFTP.FtpClient(host: FTPConnectionOptions.Server,
            user: FTPConnectionOptions.UserName,
            pass: FTPConnectionOptions.Password,
            port: FTPConnectionOptions.Port);

        rootDirectoryPath = Path.Combine(FTPConnectionOptions.Server, FTPConnectionOptions.RootDirectory);
        rootDirectory = FTPConnectionOptions.RootDirectory;
    }

    #endregion

    #region ( Methods )

    #region ( Helpers )

    public void ConnectAsync()
    {
        FtpClient.Connect();
    }

    public void DisconnectAsync()
    {
        FtpClient.Disconnect();
    }

    public async Task SetFilePermissions(string path, int permissions)
    {
        FtpClient.SetFilePermissions(Path.Combine(rootDirectory, path), DefaultPermission);
    }

    #endregion

    #region ( Set Ftp Connection )
    /// <summary>
    /// تنظیم و اتصال به سرور FTP
    /// </summary>
    /// <param name="path"> مسیر ریشه اصلی</param>
    /// <returns>موفقیت و یا عدم موفقیت عملیات را بازگشست میدهد</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public Task<bool> SetFtpConnection(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return Task.FromResult(false);
        }

        FtpClient.Encoding = Encoding.UTF8;
        FtpClient.Credentials = new NetworkCredential(FTPConnectionOptions.UserName,
            FTPConnectionOptions.Password, FTPConnectionOptions.Server);

        try
        {
            FtpClient.Connect();

            if (FtpClient.IsConnected)
            {
                //var workingDirectory = FtpClient.GetWorkingDirectory();

                if (!FtpClient.DirectoryExists(rootDirectory))
                {
                    FtpClient.CreateDirectory(rootDirectory);
                    FtpClient.SetFilePermissions(rootDirectory, DefaultPermission);
                }

                if (!FtpClient.DirectoryExists(Path.Combine(rootDirectory, path)))
                {
                    FtpClient.CreateDirectory(Path.Combine(rootDirectory, path));
                    FtpClient.SetFilePermissions(Path.Combine(rootDirectory, path), DefaultPermission);
                }

                return Task.FromResult(true);
            }
        }
        catch (FtpException exception)
        {
            FtpClient.Disconnect();

            Logger.LogError(exception, exception.InnerException?.Message ?? exception.Message);

            return Task.FromResult(false);
        }

        return Task.FromResult(false);
    }
    #endregion

    #region ( Upload File To FtpServer )

    /// <summary>
    /// ذخیره فایل و بازگشت نام فایل
    /// </summary>
    /// <param name="file">فایل مورد نظر</param>
    /// <param name="originSavePath"> مسیر ذخیره فایل اصلی</param>
    /// <param name="thumbSavePath"> مسیر ذخیره فایل ریسایز شده</param>
    /// <param name="typeFile">نوع فایل</param>
    /// <param name="deletedFileNme"> نام فایلی که باید حذف شود</param>
    /// <param name="resizeWidth">عرض</param>
    /// <param name="resizeHeight">ارتفاع</param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<string> UploadFileToFtpServer(IFormFile file, TypeFile typeFile, string originSavePath, string originSaveFilename, int permissions = 777,
        int? resizeWidth = null, int? resizeHeight = null, string thumbSavePath = null, string deleteFileName = null)
    {
        try
        {
            #region ( Exceptions )

            if (originSavePath == null) throw new ArgumentNullException(nameof(originSavePath));

            ArgumentNullException.ThrowIfNull(file);

            #endregion

            #region ( Check Is Image )

            if (typeFile == TypeFile.Image)
            {
                if (!file.IsImage()) return string.Empty;
            }

            #endregion

            #region ( Check MimeType )
            switch (typeFile)
            {
                case TypeFile.Image:
                    if (!MimeTypes.Images.Contains(file.ContentType))
                        return string.Empty;
                    break;
                case TypeFile.Video:
                    if (!MimeTypes.Videos.Contains(file.ContentType))
                        return string.Empty;
                    break;
                case TypeFile.Audio:
                    if (!MimeTypes.Audios.Contains(file.ContentType))
                        return string.Empty;
                    break;
                case TypeFile.Document:
                    if (!MimeTypes.Documents.Contains(file.ContentType))
                        return string.Empty;
                    break;
                case TypeFile.DocumentAndImage:
                    if (!MimeTypes.DocumentsAndImages.Contains(file.ContentType))
                        return string.Empty;
                    break;
                case TypeFile.Gallery:
                    if (!MimeTypes.Galleries.Contains(file.ContentType))
                        return string.Empty;
                    break;
                case TypeFile.Other:
                    if (!MimeTypes.All.Contains(file.ContentType))
                        return string.Empty;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeFile), typeFile, null);
            }

            #endregion

            #region  ( Set Ftp Connection )
            var hasConnect = await SetFtpConnection(originSavePath);
            if (!hasConnect) throw new FtpInvalidCertificateException("is not Connected");
            #endregion

            #region  ( Delete Old File )
            if (!string.IsNullOrEmpty(deleteFileName))
            {
                var fullPath = segmentSeperatorSingle + rootDirectory + originSavePath + deleteFileName;

                if (FtpClient.FileExists(fullPath)) FtpClient.DeleteFile(fullPath);

                var fullThumbPath = segmentSeperatorSingle + rootDirectory + thumbSavePath + deleteFileName;

                if (!string.IsNullOrEmpty(thumbSavePath))
                {
                    if (FtpClient.FileExists(fullThumbPath)) FtpClient.DeleteFile(fullThumbPath);
                }
            }
            #endregion

            #region ( Set FileName )

            string fileExtension = Path.GetExtension(file.FileName);
            string randomChar = Strings.RandomString();
            string fileName;

            if (!string.IsNullOrWhiteSpace(originSaveFilename))
            {
                if (typeFile == TypeFile.Video)
                {
                    fileName = Path.GetFileNameWithoutExtension(originSaveFilename) + randomChar + fileExtension;
                }
                else
                {
                    fileName = Path.GetFileNameWithoutExtension(file.FileName) + randomChar + fileExtension;
                }
            }
            else fileName = Path.GetRandomFileName() + fileExtension;

            if (typeFile is TypeFile.Image or TypeFile.DocumentAndImage)
                fileName = fileName.Replace(fileExtension, ".webp");

            #endregion

            #region  ( Create Current File )

            var originPath = segmentSeperatorSingle + rootDirectory + originSavePath + fileName;
            var response = FtpClient.UploadStream(file.OpenReadStream(), originPath, FtpRemoteExists.Overwrite, true);
            if (response == FtpStatus.Failed)
            {
                DisconnectAsync();
                return string.Empty;
            }

            #region ( Set File Permissions )

            FtpClient.SetFilePermissions(path: originPath, permissions: permissions);

            #endregion

            #region  ( Resize Image )
            if (!string.IsNullOrEmpty(thumbSavePath))
            {
                if (!FtpClient.DirectoryExists(thumbSavePath))
                    FtpClient.CreateDirectory(thumbSavePath);

                thumbSavePath += fileName;
                var extensionTypeFile = ExtensionTypeFile.Webp;
                ImageResizer(originPath, thumbSavePath, extensionTypeFile, fileExtension, resizeWidth, resizeHeight);
            }
            ;
            #endregion

            #endregion

            DisconnectAsync();
            //FtpClient.Dispose();

            return fileName;
        }
        catch (Exception e)
        {
            Logger.LogError(e, e.InnerException?.Message ?? e.Message);
            throw new FileLoadException();
        }
    }

    /// <summary>
    /// حذف فایل و بازگشت نتیجه عملیات
    /// </summary>
    /// <param name="originSavePath"> مسیر حذف فایل اصلی</param>
    /// <param name="thumbSavePath"> مسیر حذف فایل ریسایز شده احتمالی</param>
    /// <returns>نتیجه درخواست حذف فایل را بصورت bool برمیگرداند</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<bool> DeleteFileToFtpServer(string originSavePath, string deleteFileName, string? thumbSavePath = null)
    {
        try
        {
            #region  ( Delete Old File )
            if (!string.IsNullOrEmpty(deleteFileName))
            {
                var fullPath = segmentSeperatorSingle + rootDirectory + originSavePath + deleteFileName;

                if (FtpClient.FileExists(fullPath)) FtpClient.DeleteFile(fullPath);

                if (!string.IsNullOrEmpty(thumbSavePath))
                {
                    var fullThumbPath = segmentSeperatorSingle + rootDirectory + thumbSavePath + deleteFileName;
                    if (FtpClient.FileExists(fullThumbPath)) FtpClient.DeleteFile(fullThumbPath);
                }
            }
            #endregion
        }
        catch(FtpCommandException ex)
        {
            Logger.LogError(ex, ex.InnerException?.Message ?? ex.Message,
            new Hashtable
            {
                { "originSavePath", originSavePath },
                { "deleteFileName", deleteFileName },
                { "thumbSavePath", thumbSavePath }
            });

            return false;
        }
        catch(Exception ex)
        {
            Logger.LogError(ex, ex.InnerException?.Message ?? ex.Message,
            new Hashtable
            {
                { "originSavePath", originSavePath },
                { "deleteFileName", deleteFileName },
                { "thumbSavePath", thumbSavePath }
            });

            return false;
        }

        return false;
    }

    #endregion

    #region ( Download File From FtpServer )

    /// <summary>
    /// دانلود فایل و بازگشت وضعیت عملیات
    /// </summary>
    /// <param name="stream">فایل مورد نظر</param>
    /// <param name="inputImagePath"> مسیر ذخیره فایل اصلی</param>
    /// <returns>status of download file operation</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<bool> DownloadFileFromFtpServer(Stream stream, string inputImagePath)
    {
        //using var stream = new MemoryStream();
        try
        {
            #region  ( Set Ftp Connection )
            var hasConnect = await SetFtpConnection(inputImagePath);
            if (!hasConnect) throw new FtpInvalidCertificateException("is not Connected");
            #endregion

            bool fileExists = FtpClient.FileExists(inputImagePath);
            if (!fileExists)
            {
                throw new FileNotFoundException($"The file '{inputImagePath}' does not exist on the FTP server.");
            }

            var originPath = segmentSeperatorSingle + rootDirectory + inputImagePath;
            var inputFileStream = FtpClient.DownloadStream(stream, originPath, progress: progress => { });
            if (!inputFileStream)
            {
                DisconnectAsync();
                // ReSharper disable once DisposeOnUsingVariable
                await stream.DisposeAsync();

                return false;
            }
        }
        catch (FtpException exception)
        {
            DisconnectAsync();
            FtpClient.Dispose();
            // ReSharper disable once DisposeOnUsingVariable
            await stream.DisposeAsync();

            Logger.LogError(exception, exception.InnerException?.Message ?? exception.Message);

            return false;
        }

        return true;
    }

    /// <summary>
    /// دانلود فایل و بازگشت وضعیت عملیات
    /// </summary>
    /// <param name="localFilePath">فایل مورد نظر</param>
    /// <param name="ftpFilePath"> مسیر ذخیره فایل اصلی</param>
    /// <returns>status of download file operation</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public async Task<bool> DownloadFileFromFtpServer(string localFilePath, string ftpFilePath)
    {
        try
        {
            #region  ( Set Ftp Connection )
            var hasConnect = await SetFtpConnection(ftpFilePath);
            if (!hasConnect) throw new FtpInvalidCertificateException("is not Connected");
            #endregion

            bool fileExists = FtpClient.FileExists(ftpFilePath);
            if (!fileExists)
            {
                throw new FileNotFoundException($"The file '{ftpFilePath}' does not exist on the FTP server.");
            }

            var originPath = segmentSeperatorSingle + rootDirectory + ftpFilePath;
            var inputFile = FtpClient.DownloadFile(localFilePath, originPath, progress: progress => { });
            if (inputFile != FtpStatus.Success)
            {
                DisconnectAsync();
                return false;
            }
        }
        catch (FtpException exception)
        {
            DisconnectAsync();
            FtpClient.Dispose();

            Logger.LogError(exception, exception.InnerException?.Message ?? exception.Message);

            return false;
        }

        return true;
    }

    #endregion

    #region ( Resizer )
    public void ImageResizer(string inputImagePath, string outputImagePath, ExtensionTypeFile extensionTypeFile, string fileExtension, int? width, int? height)
    {
        var customWidth = width ?? 100;
        var customHeight = height ?? 100;
        IImageEncoder imageEncoder = new WebpEncoder() { Quality = 0 };

        using var stream = new MemoryStream();
        try
        {
            var inputFileStream = FtpClient.DownloadStream(stream, inputImagePath, progress: progress => { });
            if (!inputFileStream) return;

            switch (extensionTypeFile)
            {
                case ExtensionTypeFile.Webp:
                    imageEncoder = new WebpEncoder() { Quality = 0 };
                    break;
                case ExtensionTypeFile.Png:
                    imageEncoder = new PngEncoder();
                    break;
                case ExtensionTypeFile.Jpeg:
                    imageEncoder = new JpegEncoder() { Quality = 0 };
                    break;
                case ExtensionTypeFile.Jpg:
                    imageEncoder = new JpegEncoder() { Quality = 0 };
                    break;
            }

            stream.Position = 0;
            using var image = SixLabors.ImageSharp.Image.Load(stream);
            image.Mutate(x => x.Resize(customWidth, customHeight));

            using var outputStream = new MemoryStream();
            image.Save(outputStream, imageEncoder);

            var response = FtpClient.UploadStream(outputStream, outputImagePath, FtpRemoteExists.Overwrite, true);
            if (response == FtpStatus.Failed)
            {
                DisconnectAsync();

                #region ( Dispose Streams )

                // ReSharper disable once DisposeOnUsingVariable
                stream.Dispose();
                // ReSharper disable once DisposeOnUsingVariable
                outputStream.Dispose();

                #endregion
            }

            #region ( Dispose Streams )

            // ReSharper disable once DisposeOnUsingVariable
            stream.Dispose();
            // ReSharper disable once DisposeOnUsingVariable
            outputStream.Dispose();

            #endregion
        }
        catch (FtpException exception)
        {
            DisconnectAsync();
            // ReSharper disable once DisposeOnUsingVariable
            stream.Dispose();

            Logger.LogError(exception, exception.InnerException?.Message ?? exception.Message);
        }
    }
    #endregion

    #region ( Extension File Convertor )
    /// <summary>
    /// convert extension file ex : png to jpg
    /// </summary>
    /// <param name="file">file</param>
    /// <param name="originFullPath">full path like : \img\filename.jpg </param>
    /// <param name="extensionTypeFile">for ex : .png</param>
    /// <param name="thumbSavePath">if you want change thumb path </param>
    public void ConvertExtensionFileName(IFormFile file, string originFullPath, ExtensionTypeFile extensionTypeFile, string? thumbFullPath = null)
    {
        IImageEncoder imageEncoder = new JpegEncoder() { Quality = 0 };
        string oldExtension = Path.GetExtension(file.FileName);
        string newExtension = "";

        switch (extensionTypeFile)
        {
            case ExtensionTypeFile.Webp:
                newExtension = ".webp";
                imageEncoder = new WebpEncoder() { Quality = 0 };
                break;
            case ExtensionTypeFile.Png:
                newExtension = ".png";
                imageEncoder = new PngEncoder();
                break;
            case ExtensionTypeFile.Jpeg:
                newExtension = ".jpeg";
                imageEncoder = new JpegEncoder() { Quality = 0 };
                break;
            case ExtensionTypeFile.Jpg:
                newExtension = ".jpg";
                imageEncoder = new JpegEncoder() { Quality = 0 };
                break;
        }

        using var image = SixLabors.ImageSharp.Image.Load(originFullPath);
        var replacePath = originFullPath.Replace(oldExtension, newExtension);
        var response = FtpClient.UploadBytes(image.ToByteArray(), replacePath, FtpRemoteExists.Overwrite, true);
        if (response == FtpStatus.Failed)
        {
            DisconnectAsync();
        }
        image.Save(replacePath, imageEncoder);


        if (thumbFullPath == null) return;
        using var thumbImage = SixLabors.ImageSharp.Image.Load(thumbFullPath);
        var replaceThumbPath = thumbFullPath.Replace(oldExtension, newExtension);
        var responseThumb = FtpClient.UploadBytes(image.ToByteArray(), replaceThumbPath, FtpRemoteExists.Overwrite, true);
        if (responseThumb == FtpStatus.Failed)
        {
            DisconnectAsync();
        }
        image.Save(replaceThumbPath, imageEncoder);
    }
    #endregion

    #endregion
}