using Android.OS;

namespace Mal.XF.Infra.Android
{
    public abstract class MainActivityBase : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ScreenHelper.ScaleFactor = (double)Resources.DisplayMetrics.Density;

            global::Xamarin.Forms.Forms.Init(this, bundle);
        }
    }
}