using Mal.XF.Infra.Navigation;
using Prism.Commands;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Mal.XF.Infra.Pages.Master
{
    internal class MasterViewModel
    {
        private readonly INavigationService navigationService;

        public MasterViewModel(INavigationService navigationService, IMasterDetailNavigationService masterDetailNavigationService)
        {
            this.navigationService = navigationService;

            this.NavigateCommand = new DelegateCommand<INavigationToken>(this.Navigate);

            this.Tokens = masterDetailNavigationService.Tokens.Select(t => new TokenViewModel(t, this.NavigateCommand)).ToList();
            this.Title = masterDetailNavigationService.Title;
        }

        private void Navigate(INavigationToken token)
        {
            this.navigationService.NavigateByTokenAsync(token);
        }

        IReadOnlyCollection<TokenViewModel> Tokens { get; }

        public string Title { get; }

        public ICommand NavigateCommand { get; }
    }
}
