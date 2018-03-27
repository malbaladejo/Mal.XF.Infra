using Mal.XF.Infra.Navigation;
using Mal.XF.Infra.Pages.MasterMenu;
using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.Master
{
    public partial class MasterPage : MasterDetailPage
    {
        private readonly INavigationService navigationService;
        private readonly MasterMenuPage masterMenuPage;
        public NavigationPage NavigationPage { get; private set; }

        public MasterPage(MasterMenuPage masterMenuPage, INavigationService navigationService)
        {
            InitializeComponent();
            this.navigationService = navigationService;

            MasterBehavior = MasterBehavior.Popover;

            this.NavigationPage = new NavigationPage();
            this.Detail = this.NavigationPage;
            this.masterMenuPage = masterMenuPage;
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
            return this.navigationService.NavigateBack();
        }
    }
}