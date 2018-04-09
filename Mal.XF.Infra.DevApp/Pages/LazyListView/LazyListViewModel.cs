using Mal.XF.Infra.Collections;
using Mal.XF.Infra.Log;
using Prism.Mvvm;
using Prism.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.LazyListView
{
    internal class LazyListViewModel : BindableBase, INavigationAware
    {
        private readonly ILoadItemsStrategy<string> loadItemsStrategy;

        public LazyListViewModel()
        {
            this.loadItemsStrategy = new ImageLoadItemsStrategy();
            this.Images = new LazyObservableCollection<string>(this.loadItemsStrategy, 5);
        }

        public LazyObservableCollection<string> Images { get; }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}