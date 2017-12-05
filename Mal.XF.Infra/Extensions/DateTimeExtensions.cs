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
    }
}
