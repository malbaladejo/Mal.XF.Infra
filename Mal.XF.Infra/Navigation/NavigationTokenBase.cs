namespace Mal.XF.Infra.Navigation
{
    public abstract class NavigationTokenBase : INavigationToken
    {
        public virtual bool? UseModalNavigation { get; } = null;
        public virtual bool Animated { get; } = true;
    }
}