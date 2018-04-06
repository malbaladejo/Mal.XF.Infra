using Mal.XF.Infra.DevApp.Localisation;
using Mal.XF.Infra.Fonts;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.LazyListView
{
    internal class LazyListViewDisplayableToken : IDisplayableNavigationToken
    {
        public INavigationToken NavigationToken { get; } = new LazyListViewToken();
        public string Icon => IconFont.List;
        public string Label => TranslationKeys.LazyListView;
        public int DisplayOrder => 2;
    }
}