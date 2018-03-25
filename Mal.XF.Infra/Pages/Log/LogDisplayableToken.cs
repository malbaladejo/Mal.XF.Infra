using Mal.XF.Infra.Fonts;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.Pages.Log
{
    internal class LogDisplayableToken : IDisplayableNavigationToken
    {
        public INavigationToken NavigationToken { get; } = new LogToken();

        public string Icon => IconFont.Bug;

        public string Label => "Log";

        public int DisplayOrder => 1000;
    }
}
