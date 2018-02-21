using Android.Graphics;
using Android.Widget;

namespace Mal.XF.Infra.Android.Renderers
{
    internal class FontProvider
    {
        public static Typeface GetFont()
            => Typeface.CreateFromAsset(Xamarin.Forms.Forms.Context.ApplicationContext.Assets, "fontawesome.ttf");

        public static void ApplyFont(TextView textView)
        {
            textView.Typeface = GetFont();
        }
    }
}