using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.MasterMenu
{
    public partial class MasterMenuPage : ContentPage
    {
        public MasterMenuPage()
        {
            InitializeComponent();
        }

        internal void OnIsPresentedChanged()
        {
            this.ViewModel?.RefreshSelectedItem();
        }

        private MasterMenuViewModel ViewModel => this.BindingContext as MasterMenuViewModel;
    }
}