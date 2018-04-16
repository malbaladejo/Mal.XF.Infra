using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra
{
    public interface INavigationApplicationService
    {
        INavigationToken GetHomePageNavigationToken();
    }
}