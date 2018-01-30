using Mal.XF.Infra.Converters;
using Mal.XF.Infra.IO;
using Mal.XF.Infra.Net;
using Mal.XF.Infra.UWP.IO;
using Mal.XF.Infra.UWP.Net;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Mal.XF.Infra.UWP.PlatformInitializers
{
    public class UwpInitializerBase : IPlatformInitializer
    {
        public virtual void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFileService, UwpFileService>();
            container.RegisterType<INetworkService, UwpNetworkService>();
            FilePathToImageSourceConverter.RegisterInstance(container.Resolve<FilePathToImageSourceConverter>());
        }
    }
}
