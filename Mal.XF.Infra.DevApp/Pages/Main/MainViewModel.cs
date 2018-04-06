using Mal.XF.Infra.Log;
using Prism.Mvvm;
using Prism.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal class MainViewModel : BindableBase, INavigationAware
    {
        private readonly ILogger logger;

        public MainViewModel( ILogger logger)
        {
            this.logger = logger;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            this.logger.Debug($"{nameof(MainViewModel)}.{nameof(INavigationAware.OnNavigatedFrom)}");
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            this.logger.Debug($"{nameof(MainViewModel)}.{nameof(INavigationAware.OnNavigatedTo)}");
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
