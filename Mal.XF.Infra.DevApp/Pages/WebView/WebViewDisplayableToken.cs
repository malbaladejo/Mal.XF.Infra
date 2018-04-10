using Mal.XF.Infra.DevApp.Localisation;
using Mal.XF.Infra.Fonts;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.WebView
{
    internal class WebViewDisplayableToken : IDisplayableNavigationToken
    {
        public INavigationToken NavigationToken { get; } = new WebViewToken();
        public string Icon => IconFont.Globe;
        public string Label => TranslationKeys.WebView;
        public int DisplayOrder => 2;
    }
}