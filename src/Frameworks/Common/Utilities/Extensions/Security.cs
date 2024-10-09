namespace Common.Utilities.Extensions
{
    public static class Security
    {
        #region ( Password )
        public static string GetSha256Hash(string input)
        {
            using var sha256 = SHA256.Create();
            var byteValue = Encoding.UTF8.GetBytes(input);
            var byteHash = sha256.ComputeHash(byteValue);
            return Convert.ToBase64String(byteHash);
        }
        #endregion

        #region ( XSS Security )
        public static string SanitizeText(this string text)
        {
            var htmlSanitizer = new HtmlSanitizer
            {
                KeepChildNodes = true,
                AllowDataAttributes = true
            };

            return htmlSanitizer.Sanitize(text);
        }
        #endregion
    }
}