using Mal.XF.Infra.DevApp.Localisation;
using Mal.XF.Infra.Fonts;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.ResponsiveGrid
{
    internal class ResponsiveGridDisplayableToken : IDisplayableNavigationToken
    {
        public INavigationToken NavigationToken { get; } = new ResponsiveGridToken();
        public string Icon => IconFont.Th;
        public string Label => TranslationKeys.ResponsiveGrid;
        public int DisplayOrder => 2;

    }
}
