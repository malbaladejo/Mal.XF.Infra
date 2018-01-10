using System.Collections.Generic;

namespace Mal.XF.Infra.Navigation
{
    public interface IMasterDetailNavigationService
    {
        string Title { get; set; }

        void RegisterToken(IDisplayableNavigationToken token);

        IReadOnlyCollection<IDisplayableNavigationToken> Tokens { get; }
    }
}