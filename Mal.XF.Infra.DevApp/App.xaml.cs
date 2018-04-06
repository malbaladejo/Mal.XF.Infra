using Mal.XF.Infra.DevApp.Pages.LazyListView;
using Mal.XF.Infra.DevApp.Pages.Main;
using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Localisation;
using Mal.XF.Infra.Log;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Mal.XF.Infra.DevApp
{
    public partial class App 
	{
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            this.InitializeComponent();
            base.OnInitialized();
        }

        protected override void RegisterTypes()
        {
            base.RegisterTypes();

            this.RegisterViews();
            this.RegisterServices();
        }

        private void RegisterViews()
        {
            this.Container.RegisterViewForMasterDetailNavigation<MainPage, MainViewModel>(new MainDisplayableToken());
            this.Container.RegisterViewForMasterDetailNavigation<LazyListViewPage, LazyListViewModel>(new LazyListViewDisplayableToken());
        }

        private void RegisterServices()
        {
           
        }
    }
}
