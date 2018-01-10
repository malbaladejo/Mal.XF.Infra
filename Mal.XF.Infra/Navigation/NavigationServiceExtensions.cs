using Prism.Navigation;
using System.Threading.Tasks;

namespace Mal.XF.Infra.Navigation
{
    public static class NavigationServiceExtensions
    {
        public static Task NavigateByTokenAsync(this INavigationService navigationService, INavigationToken token)
        {
            var parameters = new NavigationParameters();
            parameters.AddNavigationToken(token);
            return navigationService.NavigateAsync(token.Url, parameters, token.UseModalNavigation, token.Animated);
        }
    }
}