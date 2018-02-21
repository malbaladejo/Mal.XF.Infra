using Mal.XF.Infra.Log;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.Log
{
    internal class LogSeverityToColorConverter : IValueConverter
    {
        private static Lazy<LogSeverityToColorConverter> instance = new Lazy<LogSeverityToColorConverter>(() => new LogSeverityToColorConverter());
        public static LogSeverityToColorConverter Instance = instance.Value;

        private Dictionary<LogSeverity, Color> severityColorMappings = new Dictionary<LogSeverity, Color>
        {

            [LogSeverity.Debug] = Color.Gray,
            [LogSeverity.Info] = Color.Black,
            [LogSeverity.Warning] = Color.Orange,
            [LogSeverity.Error] = Color.Red
        };

        public Color Convert(LogSeverity severity)
        {
            return this.severityColorMappings.ContainsKey(severity)
                ? this.severityColorMappings[severity]
                : Color.Black;
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value is LogSeverity ? this.Convert((LogSeverity)value) : Color.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
