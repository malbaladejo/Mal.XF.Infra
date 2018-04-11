using Mal.XF.Infra.Services;

namespace Mal.XF.Infra.Navigation
{
    internal class MasterDetailNavigationService : ServiceProvider<IDisplayableNavigationToken>, IMasterDetailNavigationService
    {
        public string Title { get; set; } = "Menu";
    }
}