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
        private readonly StorageFolder localFolder;

        public UwpFileService()
        {
            this.localFolder = ApplicationData.Current.LocalFolder;
        }

        public async Task<IReadOnlyCollection<string>> GetFilesAsync(string directoryPath)
        {
            var files = await this.localFolder.GetFilesAsync();

            return files.Select(f => f.Name).ToReadOnlyCollection();
        }

        public ImageSource GetImageSourceFromPath(string filePath)
        {
            var file = this.localFolder.GetFileAsync(filePath).AsTask().Result;
            Windows.Storage.Streams.IInputStream stream = file.OpenReadAsync().AsTask().Result;
            return ImageSource.FromStream(() => stream.AsStreamForRead());
        }

        public async Task RemoveFileAsync(string filePath)
        {
            await this.localFolder.RenameAsync(filePath);
        }
    }
}
