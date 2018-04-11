using Mal.XF.Infra.Extensions;
using Microsoft.Practices.Unity;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mal.XF.Infra.Navigation
{
    public interface INavigationService
    {
        Task NavigateByTokenAsync(INavigationToken token);
        Task<bool> NavigateBackAsync();
        INavigationToken GetCurrentNavigationToken();
    }

    internal class NavigationService : INavigationService
    {
        private readonly NavigationPage navigationPage;
        private readonly IUnityContainer container;
        private readonly List<INavigationToken> tokens = new List<INavigationToken>();
        private INavigationToken currentToken;

        public NavigationService(NavigationPage navigationPage, IUnityContainer container)
        {
            this.navigationPage = navigationPage;
            this.container = container;
        }

        public async Task NavigateByTokenAsync(INavigationToken token)
        {
            if (this.currentToken != null)
                this.tokens.Push(currentToken);
            this.currentToken = token;

            var navigationParameters = this.GetNavigationParametersFromToken(token);
            this.ManageNavigatedFrom(this.navigationPage.CurrentPage, navigationParameters);

            var page = this.GetPageFromToken(token);
            this.HideNavigationBar(page);
            this.ManageNavigatingTo(page, navigationParameters);

            await this.navigationPage.PushAsync(page);
            this.ManageNavigatedTo(page, navigationParameters);
        }

        private void HideNavigationBar(Page page)
        {
            // TODO injecter une strategy qui ne fait ca que pour les MasterDetailPages
            NavigationPage.SetHasNavigationBar(page, false);
        }

        public async Task<bool> NavigateBackAsync()
        {
            await this.navigationPage.PopAsync();
            if (!this.tokens.TryPop(out this.currentToken))
                return false;

            return true;
        }

        public INavigationToken GetCurrentNavigationToken()
            => this.currentToken;

        private NavigationParameters GetNavigationParametersFromToken(INavigationToken token)
        {
            var parameters = new NavigationParameters(token.Url);
            parameters.AddNavigationToken(token);
            return parameters;
        }

        private Page GetPageFromToken(INavigationToken token)
            => this.container.Resolve<Page>(token.Url);

        private void ManageNavigatedFrom(Page page, NavigationParameters navigationParameters)
        {
            var viewModel = page?.BindingContext as INavigationAware;
            viewModel?.OnNavigatedFrom(navigationParameters);
        }

        private void ManageNavigatedTo(Page page, NavigationParameters navigationParameters)
        {
            var viewModel = page?.BindingContext as INavigationAware;
            viewModel?.OnNavigatedTo(navigationParameters);
        }

        private void ManageNavigatingTo(Page page, NavigationParameters navigationParameters)
        {
            var viewModel = page?.BindingContext as INavigationAware;
            viewModel?.OnNavigatingTo(navigationParameters);
        }

        //private bool ManageConfirmNavigation(Page page)
        //{

        //}

        //private Task<bool> ManageConfirmNavigationAsync(Page page)
        //{

        //}
    }
}
