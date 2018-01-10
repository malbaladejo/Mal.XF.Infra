namespace Mal.XF.Infra.Navigation
{
    public interface IDisplayableNavigationToken
    {
        INavigationToken NavigationToken { get; }
        string Icon { get; }
        string Label { get; }
    }
}