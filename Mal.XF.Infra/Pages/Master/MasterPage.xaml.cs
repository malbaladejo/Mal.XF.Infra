using Mal.XF.Infra.Navigation;
using Mal.XF.Infra.Pages.MasterMenu;
using Prism.Navigation;
using System;
using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.Master
{
    public partial class MasterPage : MasterDetailPage
    {
        public NavigationPage NavigationPage { get; private set; }

        public MasterPage(Page masterMenuPage)
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
        }
    }
}