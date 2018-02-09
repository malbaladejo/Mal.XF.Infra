using Mal.XF.Infra.Extensions;
using Mal.XF.Infra.Navigation;
using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;

namespace Mal.XF.Infra.Pages.MasterMenu
{
    internal class MasterMenuViewModel : BindableBase
    {
        private readonly INavigationService navigationService;

        public MasterMenuViewModel(INavigationService navigationService, IMasterDetailNavigationService masterDetailNavigationService)
        {
            this.navigationService = navigationService;

            this.Tokens = masterDetailNavigationService.Tokens.OrderBy(t => t.DisplayOrder).ToReadOnlyCollection();
            this.Title = masterDetailNavigationService.Title;
        }

        private void Navigate(INavigationToken token)
        {
            this.navigationService.NavigateByTokenAsync(token);
        }

        public void NavigateToFirst()
        {
            this.SelectedToken = this.Tokens.FirstOrDefault();
        }

        public IReadOnlyCollection<IDisplayableNavigationToken> Tokens { get; }

        private IDisplayableNavigationToken selectedToken;

        public IDisplayableNavigationToken SelectedToken
        {
            get { return selectedToken; }
            set
            {
                if (SetProperty(ref selectedToken, value) && value != null)
                {
                    this.Navigate(value.NavigationToken);
                }
            }
        }

        public string Title { get; }
    }
}
