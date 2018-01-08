using Mal.XF.Infra.Localisation;
using Mal.XF.Infra.Navigation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace Mal.XF.Infra
{
    public abstract class ApplicationBase : PrismApplication
    {
        protected ApplicationBase(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void RegisterTypes()
        {
            var translationManager = new TranslationManager();
            this.Container.RegisterInstance<ITranslationManager>(translationManager);
            this.Container.RegisterInstance<ITranslationService>(new TranslationService(translationManager));
            this.Container.RegisterInstance<IMasterDetailNavigationService>(new MasterDetailNavigationService());
            TranslationConverter.RegisterInstance(this.Container.Resolve<TranslationConverter>());

            this.Container.RegisterTypeForNavigation<NavigationPage>();
        }
    }
}
