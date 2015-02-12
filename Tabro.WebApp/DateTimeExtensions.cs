using System;

namespace Tabro.WebApp
{
    public static class DateTimeExtensions
    {
        public static string ToEnglishString(this DateTime dateTime)
        {
            var datePart = dateTime.Day;
            var datePartExtension = (dateTime.Day%10 == 1 && dateTime.Day != 11)
                ? "st"
                : (dateTime.Day%10 == 2 && dateTime.Day != 12)
                    ? "nd"
                    : (dateTime.Day%10 == 3 && dateTime.Day != 13)
                        ? "rd"
                        : "th";

            var monthPart = dateTime.ToString("MMMM");

            var yearPart = dateTime.ToString("yy");

            return string.Format("{0}{1} of {2}, '{3}", datePart, datePartExtension, monthPart, yearPart);
        }
    }
}