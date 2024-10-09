namespace Constants.Files
{
    public static class MimeTypes
    {
        #region ( Default Types )
        public static string[] Documents = new[] { "application/pdf", "text/csv", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document" };
        public static string[] Images = new[] { "image/jpeg", "image/jpg", "image/png", "image/apng", "image/gif", "image/webp", "image/svg+xml" };
        public static string[] ImageExtensions = new[] { ".jpeg", ".jpg", ".png", ".apng", ".gif", ".webp", ".svg+xml" };
        public static string[] Audios = new[] { "audio/webm", "audio/aac", "audio/mpeg", "audio/midi", "audio/ogg", "audio/opus" };
        public static string[] Videos = new[] { "video/mp4", "video/mpeg", "video/webm" };
        public static string[] Binary = new[] { "application/octet-stream" };

        public static string Html = "text/html";
        #endregion
    }
}
