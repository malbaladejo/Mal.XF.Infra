using Prism.Mvvm;
using Prism.Navigation;

namespace Mal.XF.Infra.DevApp.Pages.WebView
{
    internal class WebViewModel : BindableBase, INavigationAware
    {
        public WebViewModel()
        {
           
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        public string Html => @"<html>
  <head>
    <title>Xamarin Forms</title>
  </head>
  <body>
    <h1>Xamrin.Forms.WebView</h1>
    <p>This is an html text display in a WebView.</p>
        </body>
        </html>";
    }
}