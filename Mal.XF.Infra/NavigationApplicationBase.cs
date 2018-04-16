using Mal.XF.Infra.Navigation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;

namespace Mal.XF.Infra
{
    public abstract class NavigationApplicationBase : ApplicationBase
    {
        private INavigationApplicationConfigurationService navigationApplicationService;

        protected NavigationApplicationBase(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            this.navigationApplicationService = new NavigationApplicationService();

            this.Container.RegisterInstance<INavigationApplicationService>(this.navigationApplicationService);
            this.Container.RegisterInstance<INavigationApplicationConfigurationService>(this.navigationApplicationService);
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.MainPage = new NavigationPage();

            this.NavigationService.NavigateByTokenAsync(this.navigationApplicationService.GetHomePageNavigationToken());
        }
    }
}