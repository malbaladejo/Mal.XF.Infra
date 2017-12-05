namespace Mal.XF.Infra.Navigation
{
    public interface INavigationToken
    {
        bool? UseModalNavigation { get; }

        bool Animated { get; }
    }
}