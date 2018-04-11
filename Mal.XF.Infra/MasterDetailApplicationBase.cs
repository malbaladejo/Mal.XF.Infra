using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Navigation;
using Mal.XF.Infra.Pages.Log;
using Mal.XF.Infra.Pages.Master;
using Mal.XF.Infra.Pages.MasterMenu;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Linq;
using Xamarin.Forms;

namespace Mal.XF.Infra
{
    public abstract class MasterDetailApplicationBase : ApplicationBase
    {
        private IMasterDetailNavigationService masterDetailNavigationService;

        protected MasterDetailApplicationBase(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();
            this.Container.RegisterInstance<IMasterDetailNavigationService>(new MasterDetailNavigationService());
            this.Container.RegisterTypeForNavigation<MasterPage>();
            this.CreateNavigationPage();

#if DEBUG
            this.Container.RegisterViewForMasterDetailNavigation<LogPage, LogViewModel, LogToken>(new LogDisplayableToken());
#endif
            this.masterDetailNavigationService = this.Container.Resolve<IMasterDetailNavigationService>();
            this.Container.RegisterViewWithViewModel<MasterMenuPage, MasterMenuViewModel>();
        }

        private void CreateNavigationPage()
        {
            var navigationPage = new NavigationPage();
            this.Container.RegisterInstance(navigationPage);
            navigationPage.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == NavigationPage.CurrentPageProperty.PropertyName)
                    navigationPage.Title = navigationPage.CurrentPage.Title;
            };
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            var rootPage = this.Container.Resolve<MasterPage>();
            this.MainPage = rootPage;
            this.Navigate();
        }

        private void Navigate()
        {
            this.Container.Resolve<INavigationService>().NavigateByTokenAsync(this.masterDetailNavigationService.Items.OrderBy(t => t.DisplayOrder).First().NavigationToken);
        }
    }
}