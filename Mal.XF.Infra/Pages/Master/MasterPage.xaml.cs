using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.Master
{
    public partial class MasterPage : MasterDetailPage
    {
        public NavigationPage NavigationPage { get; private set; }

        public MasterPage(Page masterMenuPage)
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;

            this.NavigationPage = new NavigationPage();
            this.Detail = this.NavigationPage;
            this.Master = masterMenuPage;
        }
    }
}