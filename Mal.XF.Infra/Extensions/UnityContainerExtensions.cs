using Mal.XF.Infra.Navigation;
using Microsoft.Practices.Unity;
using Prism.Mvvm;
using Prism.Unity;
using System;
using Xamarin.Forms;

namespace Mal.XF.Infra.Extensions
{
    public static class UnityContainerExtensions
    {
        public static void RegisterViewWithViewModel<TView, TViewModel>(this IUnityContainer container) where TView : Page
        {
            container.RegisterTypeForNavigation<TView>();
            ViewModelLocationProvider.Register<TView, TViewModel>();
            container.RegisterInstance<Func<TView>>(() =>
            {
                var view = container.Resolve<TView>();
                view.BindingContext = container.Resolve<TViewModel>();
                return view;
            });
        }

        public static void RegisterViewForNavigation<TView, TViewModel, TToken>(this IUnityContainer container) where TView : Page
            where TToken : INavigationToken
        {
            container.RegisterTypeForNavigation<TView>(typeof(TToken).FullName);
            ViewModelLocationProvider.Register<TView, TViewModel>();
        }

        public static void RegisterViewForMasterDetailNavigation<TView, TViewModel>(this IUnityContainer container, IDisplayableNavigationToken token) where TView : Page
        {
            container.RegisterTypeForNavigation<TView>(token.NavigationToken.GetType().FullName);
            ViewModelLocationProvider.Register<TView, TViewModel>();
            container.Resolve<IMasterDetailNavigationService>().RegisterToken(token);
        }
    }
}
