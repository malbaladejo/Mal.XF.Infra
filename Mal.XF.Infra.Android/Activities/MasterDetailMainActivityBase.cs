using Android.OS;
using Prism.Navigation;

namespace Mal.XF.Infra.Android.Activities
{
    public abstract class MasterDetailMainActivityBase : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private INavigationService navigationService;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            var app = this.GetApplication();
            this.navigationService = app.PrismNavigationService;
            LoadApplication(app);
        }

        public override void OnBackPressed()
        {
            //base.OnBackPressed();
            this.navigationService.GoBackAsync();
        }

        protected abstract ApplicationBase GetApplication();
    }
}