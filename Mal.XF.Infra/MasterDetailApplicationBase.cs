using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Navigation;
using Mal.XF.Infra.Pages.Log;
using Mal.XF.Infra.Pages.Master;
using Mal.XF.Infra.Pages.MasterMenu;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Linq;

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
            this.Container.RegisterViewWithViewModel<MasterMenuPage, MasterMenuViewModel>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            this.masterDetailNavigationService = this.Container.Resolve<IMasterDetailNavigationService>();
            var rootPage = this.Container.Resolve<MasterPage>();
            this.MainPage = rootPage;
            this.Navigate();

#if DEBUG
            this.Container.RegisterViewForMasterDetailNavigation<LogPage, LogViewModel>(new LogDisplayableToken());
#endif
        }

        private void Navigate()
        {
            this.NavigationService.NavigateByTokenAsync(this.masterDetailNavigationService.Tokens.OrderBy(t => t.DisplayOrder).First().NavigationToken);
        }
    }
}