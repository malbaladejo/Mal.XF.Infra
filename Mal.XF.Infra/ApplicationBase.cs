using Mal.XF.Infra.Converters;
using Mal.XF.Infra.Localisation;
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
            this.Container.RegisterInstance<ITranslationManager>(translationManager);
            this.Container.RegisterInstance<ITranslationService>(new TranslationService(translationManager));

            TranslationConverter.RegisterInstance(this.Container.Resolve<TranslationConverter>());
        }
    }
}
