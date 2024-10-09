using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constants
{
    public static class RegularExpression
    {
        public const string Theme = @"^[a-z][a-z_]*$";
        public const string Color = @"^#[a-fA-F0-9]{4,7}*$";

        public const string CultureRoute = @"^[arfenusARFENUS]{2}?$";
        public const string CultureRouteV2 = @"^[a-zA-Z]{2}?$";
        public const string CultureRouteV3 = @"^[a-zA-Z]{2}(\-[a-zA-Z]{2})?$";

        public const string EmptyString = @"^(\w+\S+)$";
        public const string OnlyNumber = @"^[0-9]*$";
        public const string Alphanumeric = @"^[a-zA-Z0-9]*$";
        public const string AlphanumericWithSpace = @"^[a-zA-Z0-9 ]*$";
        public const string LetterAndNumber = @"^[A-Za-z0-9]+";
        public const string DuplicateWords = @"(\b\w+\b)(?=.*\b\1\b)";
        
        public const string HtmlElements = @"/<\/?[\w\s]*>|<.+[\W]>/";
        public const string HtmlEventAttributes = @"/\bon\w+=\S+(?=.*>)/";
        public const string HtmlEventAttributesWithTag = @"/(?:<[^>]+\s)(on\S+)=[""']?((?:.(?![""']?\s+(?:\S+)=|[>""']))+.)[""']?/";

        public const string PostalCode = @"\d{10}";
        public const string VerificationCode = @"^[0-9]{6}$";

        public const string UserName = @"^@?[a-z0-9_-]{3,16}$";
        public const string Password = @"((?=.*\d)(?=.*[a-z]).{6,100})";
        public const string PhoneNumber = @"09(0[0-9]|1[0-9]|3[0-9]|2[1-9]|9[0-9])-?[0-9]{3}-?[0-9]{4}";
        public const string PhoneNumberInternational = @"^(?:(?:\+?1\s*(?:[.-]\s*)?)?(?:\(\s*([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9])\s*\)|([2-9]1[02-9]|[2-9][02-8]1|[2-9][02-8][02-9]))\s*(?:[.-]\s*)?)?([2-9]1[02-9]|[2-9][02-9]1|[2-9][02-9]{2})\s*(?:[.-]\s*)?([0-9]{4})(?:\s*(?:#|x\.?|ext\.?|extension)\s*(\d+))?$";
        public const string EmailAddress = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";

        public const string Slug = @"^[a-z0-9]+(?:-[a-z0-9]+)*$";
        public const string Slug2 = @"^[a-z0-9]+(?:(?:-)+[a-z0-9]+)*$";
        public const string Url = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
        public const string ElementsOfUrl = @"^((http[s]?|ftp):\/)?\/?([^:\/\s]+)((\/\w+)*\/)([\w\-\.]+[^#?\s]+)(.*)?(#[\w\-]+)?$";
        public const string IpAddress = @"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$";
    }
}
