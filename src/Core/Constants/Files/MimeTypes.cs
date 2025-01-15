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
        public static string[] Streams = new[] { "application/octet-stream" };

        public static string[] Html = new[] { "text/html" };

        public static string[] All = Documents
            .Concat(Images)
            .Concat(Audios)
            .Concat(Videos)
            .Concat(Streams)
            .Concat(Binary)
            .Concat(Html)
            .ToArray();

        public static string[] DocumentsAndImages = Documents
            .Concat(Images)
            .ToArray();
        #endregion
    }
}
