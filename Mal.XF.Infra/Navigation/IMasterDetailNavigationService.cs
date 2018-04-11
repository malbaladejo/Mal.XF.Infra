using Mal.XF.Infra.Services;

namespace Mal.XF.Infra.Navigation
{
    public interface IMasterDetailNavigationService : IServiceProvider<IDisplayableNavigationToken>
    {
        string Title { get; set; }
    }
}