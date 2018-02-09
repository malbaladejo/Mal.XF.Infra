using System;
using System.Globalization;

namespace Mal.XF.Infra.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime GetFirstDayOfWeek(this DateTime date)
        {
            var firstDayOfWeek = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;

            while (date.DayOfWeek != firstDayOfWeek)
                date = date.AddDays(-1);

            return date;
        }

        public static DateTime GetNextHour(this DateTime date)
            => date.Date.AddHours(date.Date.Hour + 1);

        public static DateTime GetNextHour(this DateTime date, int hour)
            => date.Hour < hour
                ? date.Date.Date.AddHours(hour)
                : date.Date.AddDays(1).Date.AddHours(hour);
    }
}
