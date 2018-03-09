using Mal.XF.Infra.Localisation;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace Mal.XF.Infra
{
    public partial class App 
	{
	    public App(IPlatformInitializer initializer = null) : base(initializer)
	    {
	    }

	    protected override void OnInitialized()
	    {
	        this.InitializeComponent();
	        base.OnInitialized();
	    }

	    protected override void RegisterTypes()
	    {
	        base.RegisterTypes();

	        this.RegisterViews();
	        this.RegisterServices();
	    }

	    private void RegisterViews()
	    {
	       // this.Container.RegisterViewForMasterDetailNavigation<MainPage, MainViewModel>(new MainDisplayableToken());
	    }

	    private void RegisterServices()
	    {
	       // this.Container.RegisterType<IBingWallpaperService, BingWallpaperService>();
	    }

	    internal void RegisterTranslationProvider(ITranslationProvider provider)
	    {
	        this.Container.Resolve<ITranslationManager>().Register(provider);
	    }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
