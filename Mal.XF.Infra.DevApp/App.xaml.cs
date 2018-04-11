using Mal.XF.Infra.DevApp.Pages.FormattedText;
using Mal.XF.Infra.DevApp.Pages.LazyListView;
using Mal.XF.Infra.DevApp.Pages.Main;
using Mal.XF.Infra.DevApp.Pages.ResponsiveGrid;
using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Navigation;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Unity;
using Xamarin.Forms;

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
            this.Container.RegisterType<IHomePageServiceProvider, HomePageServiceProvider>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<ILoadPagesStrategy, LoadPagesStrategy>(new ContainerControlledLifetimeManager());
            this.Container.RegisterType<IPageRowFactory, PageRowFactory>(new ContainerControlledLifetimeManager());

            this.Container.RegisterViewForMasterDetailNavigation<MainPage, MainViewModel, MainToken>(new MainDisplayableToken());
            this.RegisterViewForHomeNavigation<LazyListViewPage, LazyListViewModel, LazyListViewToken>(this.Container, new LazyListViewDisplayableToken());
            this.RegisterViewForHomeNavigation<ResponsiveGridPage, ResponsiveGridViewModel, ResponsiveGridToken>(this.Container, new ResponsiveGridDisplayableToken());
            this.RegisterViewForHomeNavigation<FormattedStringPage, FormattedStringViewModel, FormattedStringToken>(this.Container, new FormattedStringDisplayableToken());
        }

        private void RegisterViewForHomeNavigation<TView, TViewModel, TToken>(IUnityContainer container, IDisplayableNavigationToken token) 
            where TView : Page
            where TToken : INavigationToken
        {
            container.RegisterViewForNavigation<TView, TViewModel, TToken>();
            container.Resolve<IHomePageServiceProvider>().Register(token);
        }

        private void RegisterServices()
        {

        }
    }
}
