using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mal.XF.Infra.Converters
{
    public class InverseBoolConverter : IValueConverter
    {
        private static Lazy<InverseBoolConverter> instance = new Lazy<InverseBoolConverter>(() => new InverseBoolConverter());
        public static InverseBoolConverter Instance => instance.Value;

        public bool Convert(bool value)
            => !value;

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return this.Convert((bool)value);

            return value;
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool)
                return this.Convert((bool)value);

            return value;
        }
    }
}
