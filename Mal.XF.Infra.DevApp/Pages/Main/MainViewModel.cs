using Mal.XF.Infra.Collections;
using Mal.XF.Infra.Log;
using Prism.Mvvm;
using Prism.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal class MainViewModel : BindableBase, INavigationAware
    {
        private readonly ILogger logger;

        public MainViewModel(ILoadPagesStrategy loadPagesStrategy, ILogger logger)
        {
            this.logger = logger;
            this.Pages = new LazyObservableCollection<PageRow>(loadPagesStrategy, 5);
        }

        public LazyObservableCollection<PageRow> Pages { get; }

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
