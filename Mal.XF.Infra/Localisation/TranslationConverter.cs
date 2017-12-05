using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mal.XF.Infra.Localisation
{
    public class TranslationConverter : IValueConverter
    {
        private static TranslationConverter instance;
        private readonly ITranslationService translationService;

        public static TranslationConverter Instance
        {
            get
            {
                if (instance == null)
                    throw new InvalidOperationException($"An isntance of {nameof(TranslationConverter)} must be register using {nameof(TranslationConverter.RegisterInstance)}.");

                return instance;
            }
        }

        public static void RegisterInstance(TranslationConverter newInstance)
        {
            instance = newInstance;
        }

        public TranslationConverter(ITranslationService translationService)
        {
            this.translationService = translationService;
        }

        public string Translate(string key)
        {
            return this.translationService.GetTranslation(key);
        }

        object IValueConverter.Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return this.Translate(value as string);
        }

        object IValueConverter.ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
