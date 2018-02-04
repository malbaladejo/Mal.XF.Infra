using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.Pages.Log
{
    internal class LogDisplayableToken : IDisplayableNavigationToken
    {
        public INavigationToken NavigationToken => new LogToken();

        public string Icon => "";

        public string Label => "Log";

        public int DisplayOrder => 1000;
    }
}
