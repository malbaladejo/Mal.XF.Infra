using Mal.XF.Infra.Android.Renderers;
using Mal.XF.Infra.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconButton), typeof(IconButtonRenderer))]

namespace Mal.XF.Infra.Android.Renderers
{
    public class IconButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null) return;
            FontProvider.ApplyFont(this.Control);
        }
    }
}