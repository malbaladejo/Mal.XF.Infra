using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra
{
    public interface INavigationApplicationConfigurationService : INavigationApplicationService
    {
        void RegisterHomePageNavigationToken(INavigationToken homePageToken);
    }
}