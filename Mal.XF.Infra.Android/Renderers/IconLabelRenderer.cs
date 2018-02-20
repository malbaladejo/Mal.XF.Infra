using Android.Graphics;
using Java.Lang;
using Mal.XF.Infra.Android.Renderers;
using Mal.XF.Infra.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(IconLabel), typeof(IconLabelRenderer))]

namespace Mal.XF.Infra.Android.Renderers
{

    public class IconLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            try
            {
                base.OnElementChanged(e);
                if (e.OldElement == null)
                {
                    var font = Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.ApplicationContext.Assets, "fontawesome.ttf");
                    //Control.SetTypeface(font, TypefaceStyle.Normal);
                    Control.Typeface = font;
                }
            }
            catch (Exception exp)
            {

            }
        }
    }
}