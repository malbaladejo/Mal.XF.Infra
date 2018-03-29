using System;
using Xamarin.Forms;

namespace Mal.XF.Infra.Pages.Log
{
    public partial class LogPage : ContentPage
    {
        public LogPage()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {

            }
        }

        private void OnItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            if (this.ViewModel == null)
                return;

            this.ViewModel.LoadItems();
        }

        private LogViewModel ViewModel => this.BindingContext as LogViewModel;
    }
}
