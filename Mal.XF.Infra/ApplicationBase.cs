using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Localisation;
using Mal.XF.Infra.Log;
using Mal.XF.Infra.Navigation;
using Mal.XF.Infra.Pages.Log;
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
            var logManager = new LogManager();

            this.Container.RegisterInstance<ITranslationManager>(translationManager);
            this.Container.RegisterInstance<ITranslationService>(new TranslationService(translationManager));
            this.Container.RegisterInstance<ILogManager>(logManager);
#if DEBUG
            this.Container.RegisterInstance<ILogger>(new Logger(logManager, LogSeverity.Debug));
#else
            this.Container.RegisterInstance<ILogger>(new Logger(logManager, LogSeverity.Error));
#endif
            this.Container.RegisterInstance<IMasterDetailNavigationService>(new MasterDetailNavigationService());
            TranslationConverter.RegisterInstance(this.Container.Resolve<TranslationConverter>());

            this.Container.RegisterTypeForNavigation<NavigationPage>();

            this.Container.RegisterViewForMasterDetailNavigation<LogPage, LogViewModel>(new LogDisplayableToken());
        }
    }
}
