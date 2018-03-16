using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Navigation;
using Mal.XF.Infra.Pages.Log;
using Mal.XF.Infra.Pages.Master;
using Mal.XF.Infra.Pages.MasterMenu;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Mal.XF.Infra
{
    public abstract class MasterDetailApplicationBase : ApplicationBase
    {
        protected MasterDetailApplicationBase(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            var menu = new MasterMenuPage();
            var menuVm = new MasterMenuViewModel(this.NavigationService, this.Container.Resolve<IMasterDetailNavigationService>());
            menu.BindingContext = menuVm;
            var rootPage = new MasterPage(menu);
            this.MainPage = rootPage;
            menuVm.NavigateToFirst();

#if DEBUG
            this.Container.RegisterViewForMasterDetailNavigation<LogPage, LogViewModel>(new LogDisplayableToken());
#endif
        }
    }
}