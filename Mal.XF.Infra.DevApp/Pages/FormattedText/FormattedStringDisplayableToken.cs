using Mal.XF.Infra.DevApp.Localisation;
using Mal.XF.Infra.Fonts;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.FormattedText
{
    internal class FormattedStringDisplayableToken : IDisplayableNavigationToken
    {
        public INavigationToken NavigationToken { get; } = new FormattedStringToken();
        public string Icon => IconFont.Font;
        public string Label => TranslationKeys.FormattedString;
        public int DisplayOrder => 2;
    }
}
