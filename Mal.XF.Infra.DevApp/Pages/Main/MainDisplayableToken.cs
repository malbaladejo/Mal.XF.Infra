using Mal.XF.Infra.DevApp.Localisation;
using Mal.XF.Infra.Fonts;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal class MainDisplayableToken : IDisplayableNavigationToken
    {
        public INavigationToken NavigationToken { get; } = new MainToken();
        public string Icon => IconFont.Home;
        public string Label => TranslationKeys.Home;
        public int DisplayOrder => 1;
    }
}