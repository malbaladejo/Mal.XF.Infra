using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace Mal.XF.Infra.DevApp.Pages.FormattedText
{
    internal class FormattedStringViewModel : BindableBase, INavigationAware
    {
        public FormattedStringViewModel()
        {
            this.FormattedString = new FormattedString();
            this.FormattedString.Spans.Clear();
            this.FormattedString.Spans.Add(new Span { Text = "First ", ForegroundColor = Color.Red, Font = Font.SystemFontOfSize(14) });
            this.FormattedString.Spans.Add(new Span { Text = " second ", ForegroundColor = Color.Blue, Font = Font.SystemFontOfSize(28) });
            this.FormattedString.Spans.Add(new Span { Text = " third.", ForegroundColor = Color.Yellow, Font = Font.SystemFontOfSize(14) });

            this.HtmlString = "<h1>title</h1><b>bold</bold><br /> <strike>strike</strike>";
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


        public FormattedString FormattedString { get; }

        public string HtmlString { get;}
    }
}
