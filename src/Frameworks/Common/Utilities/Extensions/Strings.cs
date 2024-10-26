namespace Common.Utilities.Extensions
{
    public static class Strings
    {
        public static bool HasValue(this string value, bool ignoreWhiteSpace = true)
        {
            return ignoreWhiteSpace ? !string.IsNullOrWhiteSpace(value) : !string.IsNullOrEmpty(value);
        }

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return Convert.ToDecimal(value);
        }

        public static string ToNumeric(this int value)
        {
            return value.ToString("N0"); //"123,456"
        }

        public static string ToNumeric(this decimal value)
        {
            return value.ToString("N0");
        }

        public static string ToCurrency(this int value)
        {
            //fa-IR => current culture currency symbol => ریال
            //123456 => "123,123ریال"
            return value.ToString("C0");
        }

        public static string ToCurrency(this decimal value)
        {
            return value.ToString("C0");
        }

        public static string ToSlug(this string value)
        {
            return value.Trim().ToLower()
                .Replace("~", "")
                .Replace("@", "")
                .Replace("#", "")
                .Replace("$", "")
                .Replace("%", "")
                .Replace("^", "")
                .Replace("&", "")
                .Replace("*", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("+", "")
                .Replace(" ", "-")
                .Replace(">", "")
                .Replace("<", "")
                .Replace(@"\", "")
                .Replace("/", "");
        }

        public static string SlugToText(this string value)
        {
            return value.Trim().ToLower()
                .Replace("-", " ")
                .Replace("+", " ");
        }

        public static string ArrayToString(this string[] strArray)
        {
            var sb = new StringBuilder();
            foreach (var item in strArray)
            {
                sb.Append(item);
                if (!item.Equals(strArray[^1]))
                {
                    sb.Append(",");
                }
            }

            return sb.ToString();
        }

        public static string RandomString(int length = 6)
        {
            const string chars = "0123456789aAbBcCdDeE";

            Random random = new Random();

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
