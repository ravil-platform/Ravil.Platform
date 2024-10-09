namespace Common.Utilities.Extensions
{
    public static class DateTimes
    {
        #region ( To Shamsi Date )
        public static string ToShamsiDate(this DateTime value)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            return persianCalendar.GetYear(value) + "/" +
                   persianCalendar.GetMonth(value).ToString("00") + "/" +
                   persianCalendar.GetDayOfMonth(value).ToString("00");
        }
        #endregion

        #region ( To String Shamsi Date )
        public static string ToStringShamsiDate(this DateTime dt)
        {
            PersianCalendar persianCalendar = new PersianCalendar();

            int intYear = persianCalendar.GetYear(dt);
            int intMonth = persianCalendar.GetMonth(dt);
            int intDayOfMonth = persianCalendar.GetDayOfMonth(dt);
            DayOfWeek enDayOfWeek = persianCalendar.GetDayOfWeek(dt);

            string strMonthName = "";
            string strDayName = "";

            switch (intMonth)
            {
                case 1:
                    strMonthName = "فروردین";
                    break;
                case 2:
                    strMonthName = "اردیبهشت";
                    break;
                case 3:
                    strMonthName = "خرداد";
                    break;
                case 4:
                    strMonthName = "تیر";
                    break;
                case 5:
                    strMonthName = "مرداد";
                    break;
                case 6:
                    strMonthName = "شهریور";
                    break;
                case 7:
                    strMonthName = "مهر";
                    break;
                case 8:
                    strMonthName = "آبان";
                    break;
                case 9:
                    strMonthName = "آذر";
                    break;
                case 10:
                    strMonthName = "دی";
                    break;
                case 11:
                    strMonthName = "بهمن";
                    break;
                case 12:
                    strMonthName = "اسفند";
                    break;
                default:
                    strMonthName = "";
                    break;
            }

            switch (enDayOfWeek)
            {
                case DayOfWeek.Friday:
                    strDayName = "جمعه";
                    break;
                case DayOfWeek.Monday:
                    strDayName = "دوشنبه";
                    break;
                case DayOfWeek.Saturday:
                    strDayName = "شنبه";
                    break;
                case DayOfWeek.Sunday:
                    strDayName = "یکشنبه";
                    break;
                case DayOfWeek.Thursday:
                    strDayName = "پنجشنبه";
                    break;
                case DayOfWeek.Tuesday:
                    strDayName = "سه شنبه";
                    break;
                case DayOfWeek.Wednesday:
                    strDayName = "چهارشنبه";
                    break;
                default:
                    strDayName = "";
                    break;
            }

            return ($"{strDayName} {intDayOfMonth} {strMonthName} {intYear}");
        }
        #endregion

        #region ( To Short Time )
        public static string ToShortTime(this TimeSpan timeSpan)
        {
            return timeSpan.Hours.ToString("00") + ":" + timeSpan.Minutes.ToString("00");
        }
        #endregion

        #region ( Get Hour And Minutes )
        public static string GetHourAndMinutesFormat(this DateTime time)
        {
            return time.ToString("HH:mm");
        }
        #endregion
    }
}
