using Prism.Navigation;

namespace Mal.XF.Infra.Navigation
{
    public static class NavigationParametersExtensions
    {
        private const string tokenKey = "NavigationParametersToken";

        public static void AddNavigationToken<TToken>(this NavigationParameters parameters, TToken token) where TToken : INavigationToken
        {
            parameters.Add(tokenKey, token);
        }

        public static TToken ExtractNavigationToken<TToken>(this NavigationParameters parameters) where TToken : INavigationToken
        {
            if (parameters.ContainsKey(tokenKey) && parameters[tokenKey] is TToken)
                return (TToken)parameters[tokenKey];
            return default(TToken);
        }
    }
}