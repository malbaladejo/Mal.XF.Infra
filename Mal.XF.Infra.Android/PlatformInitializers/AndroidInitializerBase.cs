using Mal.XF.Infra.Android.IO;
using Mal.XF.Infra.Android.Net;
using Mal.XF.Infra.Converters;
using Mal.XF.Infra.IO;
using Mal.XF.Infra.Net;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Mal.XF.Infra.Android.PlatformInitializers
{
    public class AndroidInitializerBase : IPlatformInitializer
    {
        public virtual void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IFileService, AndroidFileService>();
            container.RegisterType<INetworkService, AndroidNetworkService>();

            FilePathToImageSourceConverter.RegisterInstance(container.Resolve<FilePathToImageSourceConverter>());
        }
    }
}
