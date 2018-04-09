
using Android.App;
using Android.Content.PM;
using Android.OS;
using Mal.XF.Infra.Android;

namespace Mal.XF.Infra.DevApp.Droid
{
    [Activity(Label = "Mal.XF.Infra.DevApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : MainActivityBase
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            LoadApplication(new App(new AndroidInitializer()));
        }
    }
}

