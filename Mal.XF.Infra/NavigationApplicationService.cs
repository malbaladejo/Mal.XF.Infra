using Mal.XF.Infra.Navigation;
using System;

namespace Mal.XF.Infra
{
    internal class NavigationApplicationService : INavigationApplicationConfigurationService
    {
        private INavigationToken homePageToken;

        public INavigationToken GetHomePageNavigationToken()
        {
            if (this.homePageToken == null)
                throw new InvalidOperationException("You must set an instance of INavigationToken using INavigationApplicationConfigurationService.RegisterHomePageNavigationToken.");
            return this.homePageToken;
        }

        public void RegisterHomePageNavigationToken(INavigationToken newHomePageToken)
        {
            this.homePageToken = newHomePageToken;
        }
    }
}