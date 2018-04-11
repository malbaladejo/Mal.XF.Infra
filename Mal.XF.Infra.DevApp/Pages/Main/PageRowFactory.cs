using Mal.XF.Infra.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.Main
{
    internal class PageRowFactory: IPageRowFactory
    {
        private readonly INavigationService navigationService;

        public PageRowFactory(INavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        public IDisplayableNavigationToken CreateToken(IDisplayableNavigationToken token)
            => new PageCellViewModel(token, this.navigationService);
    }
}
