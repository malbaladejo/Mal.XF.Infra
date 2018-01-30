using Android.App;
using Android.Content;
using Android.Net.Wifi;
using Mal.XF.Infra.Net;
using System;

namespace Mal.XF.Infra.Android.Net
{
    internal class AndroidNetworkService : INetworkService
    {
        public bool IsWifiEnabled()
        {
            try
            {
                var wifiManager = (WifiManager)Application.Context.GetSystemService(Context.WifiService);
                return wifiManager.IsWifiEnabled;
            }
            catch (Exception e)
            {
                throw new Exception("Have you defined user permissions android.permission.ACCESS_WIFI_STATE and android.permission.ACCESS_NETWORK_STATE?", e);
            }
        }

    }
}