using Mal.XF.Infra.Navigation;
using Prism.Commands;
using System.Windows.Input;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal class PageCellViewModel: IDisplayableNavigationToken
    {
        private readonly IDisplayableNavigationToken token;

        public PageCellViewModel(IDisplayableNavigationToken token, INavigationService navigationService)
        {
            this.token = token;
            this.NavigateCommand =
                new DelegateCommand(() => navigationService.NavigateByTokenAsync(this.NavigationToken));
        }

        public INavigationToken NavigationToken => this.token.NavigationToken;
        public string Icon => this.token.Icon;
        public string Label => this.token.Label;
        public int DisplayOrder => this.token.DisplayOrder;    

        public ICommand NavigateCommand { get; }
    }
}
