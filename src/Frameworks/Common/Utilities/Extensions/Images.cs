namespace Common.Utilities.Extensions
{
    public static class Images
    {
        #region ( Security )
        public const int ImageMinimumBytes = 512;

        public static bool IsImage(this IFormFile postedFile)
        {
            //-------------------------------------------
            //  Check the image mime types
            //-------------------------------------------
            var validTypes = MimeTypes.Images;

            if (!validTypes.Contains(postedFile.ContentType))
            {
                return false;
            }

            //-------------------------------------------
            //  Check the image extension
            //-------------------------------------------
            var validExtension = MimeTypes.ImageExtensions;

            if (!validExtension.Contains(Path.GetExtension(postedFile.FileName).ToLower()))
            {
                return false;
            }

            //-------------------------------------------
            //  Attempt to read the file and check the first bytes
            //-------------------------------------------
            try
            {
                if (!postedFile.OpenReadStream().CanRead)
                {
                    return false;
                }
                //------------------------------------------
                //check whether the image size exceeding the limit or not
                //------------------------------------------ 
                if (postedFile.Length < ImageMinimumBytes)
                {
                    return false;
                }

                byte[] buffer = new byte[ImageMinimumBytes];
                postedFile.OpenReadStream().Read(buffer, 0, ImageMinimumBytes);
                string content = System.Text.Encoding.UTF8.GetString(buffer);
                if (Regex.IsMatch(content, @"<script|<html|<head|<title|<body|<pre|<table|<a\s+href|<img|<plaintext|<cross\-domain\-policy",
                    RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Multiline))
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region ( Resizer )
        public static void ImageResizer(string inputImagePath, string outputImagePath, int? width, int? height)
        {
            var customWidth = width ?? 100;

            var customHeight = height ?? 100;

            using var image = SixLabors.ImageSharp.Image.Load(inputImagePath);

            image.Mutate(x => x.Resize(customWidth, customHeight));

            image.Save(outputImagePath, new JpegEncoder
            {
                Quality = 100
            });
        }
        #endregion

        #region ( Save File )
        public static void AddImageToServer(this IFormFile image, string fileName, string originSavePath, TypeFile typeFile, int? resizeWidth = null, int? resizeHeight = null, string? thumbSavePath = null, string? deleteFileName = null)
        {
            try
            {
                if (typeFile == TypeFile.Image)
                {
                    if (!image.IsImage()) return;
                }

                #region  ( Create Save Path Directory )
                if (!Directory.Exists(originSavePath)) Directory.CreateDirectory(originSavePath);
                #endregion

                #region  ( Delete Old File )
                if (!string.IsNullOrEmpty(deleteFileName))
                {
                    try
                    {
                        var fullPath = $"{originSavePath}/{deleteFileName}";

                        if (File.Exists(fullPath)) File.Delete(fullPath);

                        var fullThumbPath = thumbSavePath + deleteFileName;

                        if (!string.IsNullOrEmpty(thumbSavePath))
                        {
                            if (File.Exists(fullThumbPath)) File.Delete(fullThumbPath);
                        }
                    }
                    catch { }
                }
                #endregion

                #region  ( Create Current File )
                var originPath = $"{originSavePath}/{fileName}";

                using (var stream = new FileStream(originPath, FileMode.Create))
                {
                    if (!Directory.Exists(originPath)) image.CopyTo(stream);
                }

                #region  ( Resize Image )
                if (typeFile == TypeFile.Image)
                {
                    if (string.IsNullOrEmpty(thumbSavePath)) return;

                    if (!Directory.Exists(thumbSavePath)) Directory.CreateDirectory(thumbSavePath);

                    if (resizeWidth != null && resizeHeight != null)
                    {
                        ImageResizer(originSavePath + fileName, thumbSavePath + fileName, resizeWidth, resizeHeight);
                    }
                }
                #endregion
                #endregion
            }
            catch
            {
                throw;
            }
        }

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
        public static string SaveFileAndReturnName(this IFormFile file, string originSavePath, TypeFile typeFile, int? resizeWidth = null, int? resizeHeight = null, string? thumbSavePath = null, string? deletedFileNme = null)
        {
            if (originSavePath == null) throw new ArgumentNullException(nameof(originSavePath));

            ArgumentNullException.ThrowIfNull(file);

            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);

            file.AddImageToServer(fileName, originSavePath, typeFile, resizeWidth, resizeHeight, thumbSavePath, deletedFileNme);

            return fileName;
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
        public static void ConvertExtensionFileName(this IFormFile file, string originFullPath, ExtensionTypeFile extensionTypeFile, string? thumbFullPath = null)
        {
            string oldExtension = Path.GetExtension(file.FileName);
            string newExtension = "";

            switch (extensionTypeFile)
            {
                case ExtensionTypeFile.Webp:
                    newExtension = ".webp";
                    break;
                case ExtensionTypeFile.Png:
                    newExtension = ".png";
                    break;
                case ExtensionTypeFile.Jpeg:
                    newExtension = ".jpeg";
                    break;
                case ExtensionTypeFile.Jpg:
                    newExtension = ".jpg";
                    break;
            }

            using var image = SixLabors.ImageSharp.Image.Load(originFullPath);
            var replacePath = originFullPath.Replace(oldExtension, newExtension);
            image.Save(replacePath);

            if (thumbFullPath == null) return;
            using var thumbImage = SixLabors.ImageSharp.Image.Load(thumbFullPath);
            var replaceThumbPath = thumbFullPath.Replace(oldExtension, newExtension);
            image.Save(replaceThumbPath);

        }
        #endregion

        #region ( Image To ByteArray )
        public static byte[] ToByteArray(this Image current)
        {
            using (var stream = new MemoryStream())
            {
                current.Save(stream, new JpegEncoder
                {
                    Quality = 100
                });
                return stream.ToArray();
            }
        }
        #endregion
    }

    public enum TypeFile
    {
        Image, Video, Audio, Document, DocumentAndImage, Other
    }

    public enum ExtensionTypeFile
    {
        Webp, Png, Jpeg, Jpg,
    }
}
