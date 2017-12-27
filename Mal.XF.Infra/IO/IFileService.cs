using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mal.XF.Infra.IO
{
    public interface IFileService
    {
        Task<IReadOnlyCollection<string>> GetFilesAsync(string directoryPath);
        Task RemoveFileAsync(string filePath);
        ImageSource GetImageSourceFromPath(string filePath);
    }
}
