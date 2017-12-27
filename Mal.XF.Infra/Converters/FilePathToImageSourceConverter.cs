using Mal.XF.Infra.IO;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace Mal.XF.Infra.Converters
{
    public class FilePathToImageSourceConverter : IValueConverter
    {
        private static FilePathToImageSourceConverter instance;
        private readonly IFileService fileService;

        public static FilePathToImageSourceConverter Instance
        {
            get
            {
                if (instance == null)
                    throw new InvalidOperationException($"An isntance of {nameof(FilePathToImageSourceConverter)} must be register using {nameof(FilePathToImageSourceConverter.RegisterInstance)}.");

                return instance;
            }
        }

        public static void RegisterInstance(FilePathToImageSourceConverter newInstance)
        {
            instance = newInstance;
        }

        public FilePathToImageSourceConverter(IFileService fileService)
        {
            this.fileService = fileService;
        }

        public ImageSource Convert(string filePath)
        {
            try
            {
                return this.fileService.GetImageSourceFromPath(filePath);
            }
            catch
            {
                return null;
            }
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => this.Convert(value as string);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
