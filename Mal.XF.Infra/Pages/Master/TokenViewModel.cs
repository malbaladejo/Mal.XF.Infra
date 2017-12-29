using System.Windows.Input;
using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.Pages.Master
{
    internal class TokenViewModel : IDisplayableNavigationToken
    {
        public ICommand NavigateCommand { get; }
        private readonly IDisplayableNavigationToken token;

        public TokenViewModel(IDisplayableNavigationToken token, ICommand navigateCommand)
        {
            NavigateCommand = navigateCommand;
            this.token = token;
        }

        public INavigationToken NavigationToken => this.token.NavigationToken;
        public string Icon => this.token.Icon;
        public string Label => this.token.Label;
    }
}