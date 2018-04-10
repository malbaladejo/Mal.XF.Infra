using Android.Text;
using Android.Widget;
using Mal.XF.Infra.Android.Renderers;
using Mal.XF.Infra.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// see https://theconfuzedsourcecode.wordpress.com/2017/02/05/awesome-xamarin-forms-label-with-html-text-formatting/
[assembly: ExportRenderer(typeof(HtmlLabel), typeof(HtmlLabelRenderer))]
namespace Mal.XF.Infra.Android.Renderers
{
    public class HtmlLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlLabel)Element;
            if (view == null) return;

            // see https://stackoverflow.com/questions/37904739/html-fromhtml-deprecated-in-android-n
            Control.SetText(Html.FromHtml(view.Text.ToString()), TextView.BufferType.Spannable);
        }
    }
}