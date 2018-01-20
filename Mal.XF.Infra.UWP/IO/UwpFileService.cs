using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;

namespace Mal.XF.Infra.UWP.IO
{
    public class UwpFileService : IFileService
    {
        public async Task<IReadOnlyCollection<string>> GetFilesAsync(string directoryPath)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var files = await storageFolder.GetFilesAsync();

            return files.Select(f => f.Name).ToReadOnlyCollection();
        }

        public ImageSource GetImageSourceFromPath(string filePath)
        {
            var file = ApplicationData.Current.LocalFolder.GetFileAsync(filePath).AsTask().Result;
            Windows.Storage.Streams.IInputStream stream = file.OpenReadAsync().AsTask().Result;
            return ImageSource.FromStream(() => stream.AsStreamForRead());
        }

        private async Task GetImageSourceFromPathAsync(string filePath)
        {

        }

        public async Task RemoveFileAsync(string filePath)
        {
            await Task.Delay(10);
        }
    }
}
