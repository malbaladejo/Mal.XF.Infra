using Android.Content;
using Android.Graphics;
using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.IO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Application = Android.App.Application;

namespace Mal.XF.Infra.Android.IO
{
    public class AndroidFileService : IFileService
    {
        public async Task<IReadOnlyCollection<string>> GetFilesAsync(string directoryPath)
        {
            var cw = new ContextWrapper(Application.Context);
            var directory = cw.GetDir(directoryPath, FileCreationMode.Private);
            var files = await directory.ListFilesAsync();

            return files.Select(f => f.AbsolutePath).ToReadOnlyCollection();
        }

        public Task RemoveFileAsync(string filePath)
        {
            return Task.Run(() =>
            {
                var file = new Java.IO.File(filePath);
                file.Delete();
            });
        }

        public ImageSource GetImageSourceFromPath(string filePath)
        {
            return ImageSource.FromStream(() =>
            {
                var bmp = BitmapFactory.DecodeFile(filePath);
                var ms = new MemoryStream();
                bmp.Compress(Bitmap.CompressFormat.Jpeg, 100, ms);
                ms.Seek(0L, SeekOrigin.Begin);
                return ms;
            });
        }
    }
}