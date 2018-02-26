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

        public static DateTime GetCurrentDatePlusOneHour(this DateTime date)
        {
            return date.Date.AddHours(date.Hour + 1);
        }

        public static DateTime GetNextHour(this DateTime date, int hour)
        {
            return date.Hour < hour
                    ? date.Date.AddHours(hour)
                    : date.AddDays(1).Date.AddHours(hour);
        }
    }
}
