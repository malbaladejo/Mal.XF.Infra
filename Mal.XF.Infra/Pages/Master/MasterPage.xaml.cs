using Mal.XF.Infra.Navigation;
using Mal.XF.Infra.Pages.MasterMenu;
using System;
using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.Master
{
    public partial class MasterPage : MasterDetailPage
    {
        private readonly MasterMenuPage masterMenuPage;
        private readonly NavigationPage navigationPage;
        private readonly INavigationService navigationService;

        public MasterPage(MasterMenuPage masterMenuPage, NavigationPage navigationPage, INavigationService navigationService)
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            this.Detail = new NavigationPage(navigationPage);

            (masterMenuPage.BindingContext as MasterMenuViewModel)?.SetHideMaster(() => this.IsPresented = false);

            this.masterMenuPage = masterMenuPage;
            this.navigationPage = navigationPage;
            this.navigationService = navigationService;
            this.Master = this.masterMenuPage;

            this.IsPresentedChanged += OnIsPresentedChanged;
        }

        private void OnIsPresentedChanged(object sender, EventArgs e)
        {
            if (this.IsPresented)
                this.masterMenuPage.OnIsPresentedChanged();
        }

        protected override bool OnBackButtonPressed()
        {
            this.navigationService.NavigateBackAsync();
            return true;
        }
    }
}