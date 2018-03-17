using Mal.XF.Infra.Navigation;
using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.Master
{
    public partial class MasterPage : MasterDetailPage
    {
        private readonly INavigationService navigationService;

        public NavigationPage NavigationPage { get; private set; }

        public MasterPage(Page masterMenuPage, INavigationService navigationService)
        {
            try
            {
                InitializeComponent();
                MasterBehavior = MasterBehavior.Popover;

                this.NavigationPage = new NavigationPage();
                this.Detail = this.NavigationPage;
                this.Master = masterMenuPage;
            }
            catch (Exception e)
            {

            }

            this.navigationService = navigationService;
        }

        protected override bool OnBackButtonPressed()
        {
            return this.navigationService.NavigateBack();
        }
    }
}