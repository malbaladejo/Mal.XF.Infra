using Mal.XF.Infra.Navigation;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Unity;
using Xamarin.Forms;

namespace Mal.XF.Infra.Extensions
{
    public static class UnityContainerExtensions
    {
        public static void RegisterViewWithViewModel<TView, TViewModel>(this IUnityContainer container) where TView : Page
        {
            container.RegisterTypeForNavigation<TView>();
            ViewModelLocationProvider.Register<TView, TViewModel>();
            container.RegisterType<TView>(new InjectionProperty(nameof(Page.BindingContext), new ResolvedParameter<TViewModel>()));
        }

        public static void RegisterViewForNavigation<TView, TViewModel, TToken>(this IUnityContainer container)
            where TView : Page
            where TToken : INavigationToken
        {
            container.RegisterType<Page, TView>(typeof(TToken).FullName, new InjectionProperty(nameof(Page.BindingContext), new ResolvedParameter<TViewModel>()));
        }

        public static void RegisterViewForMasterDetailNavigation<TView, TViewModel, TToken>(this IUnityContainer container, IDisplayableNavigationToken token)
            where TView : Page
            where TToken : INavigationToken
        {
            container.RegisterViewForNavigation<TView, TViewModel, TToken>();
            container.Resolve<IMasterDetailNavigationService>().Register(token);
        }
    }
}
