using Mal.XF.Infra.Android.PlatformInitializers;
using Mal.XF.Infra.DevApp.Localisation;
using Mal.XF.Infra.Localisation;
using Microsoft.Practices.Unity;

namespace Mal.XF.Infra.DevApp.Droid
{
    internal class AndroidInitializer : AndroidInitializerBase
    {
        public override void RegisterTypes(IUnityContainer container)
        {
            base.RegisterTypes(container);

            container.Resolve<ITranslationManager>().Register(new LocalTranslationProvider("Mal.XF.Infra.DevApp.Droid.Localisation.Resources", typeof(LocalTranslationProvider).Assembly));
        }
    }
}