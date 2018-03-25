using Mal.XF.Infra.Extensions;
using Prism.Navigation;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Navigation
{
    public static class NavigationServiceExtensions
    {
        private static List<INavigationToken> tokens = new List<INavigationToken>();
        private static INavigationToken currentToken;

        public static Task NavigateByTokenAsync(this INavigationService navigationService, INavigationToken token)
        {
            if (currentToken != null)
                tokens.Push(currentToken);

            currentToken = token;
            return navigationService.NavigateAsync(token);
        }

        public static bool NavigateBack(this INavigationService navigationService)
        {
            if (!tokens.TryPop(out currentToken))
                return false;

            navigationService.NavigateAsync(currentToken);

            return true;
        }

        public static INavigationToken GetCurrentNavigationToken(this INavigationService navigationService) => currentToken;

        private static Task NavigateAsync(this INavigationService navigationService, INavigationToken token)
        {
            var parameters = new NavigationParameters();
            parameters.AddNavigationToken(token);
            return navigationService.NavigateAsync(token.Url, parameters, token.UseModalNavigation, token.Animated);
        }
    }
}