using Mal.XF.Infra.Android.IO;
using Mal.XF.Infra.Converters;
using Mal.XF.Infra.IO;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Mal.XF.Infra.Android.PlatformInitializers
{
    public class AndroidInitializerBase : IPlatformInitializer
    {
        public virtual void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFileService, AndroidFileService>();
            FilePathToImageSourceConverter.RegisterInstance(container.Resolve<FilePathToImageSourceConverter>());
        }
    }
}
