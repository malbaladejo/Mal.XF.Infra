using System.Collections.Generic;

namespace Mal.XF.Infra.Navigation
{
    internal class MasterDetailNavigationService : IMasterDetailNavigationService
    {
        private readonly List<IDisplayableNavigationToken> tokens;

        public MasterDetailNavigationService()
        {
            this.tokens = new List<IDisplayableNavigationToken>();
        }

        public string Title { get; set; } = "Menu";

        public void RegisterToken(IDisplayableNavigationToken token)
            => this.tokens.Add(token);

        public IReadOnlyCollection<IDisplayableNavigationToken> Tokens => this.tokens;
    }
}