using Mal.XF.Infra.Net;

namespace Mal.XF.Infra.UWP.Net
{
    internal class UwpNetworkService : INetworkService
    {
        public bool IsWifiEnabled()
        {
            var internetConnectionProfile = Windows.Networking.Connectivity.NetworkInformation.GetInternetConnectionProfile();
            return internetConnectionProfile?.IsWlanConnectionProfile ?? false;
        }
    }
}