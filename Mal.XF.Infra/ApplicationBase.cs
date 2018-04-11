using Mal.XF.Infra.Localisation;
using Mal.XF.Infra.Log;
using Mal.XF.Infra.Navigation;
using Microsoft.Practices.Unity;
using Prism.Unity;

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
            TranslationConverter.RegisterInstance(this.Container.Resolve<TranslationConverter>());
            this.Container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
        }

        protected override void OnInitialized()
        {
        }
    }
}
