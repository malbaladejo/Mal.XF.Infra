using Xamarin.Forms;

namespace Mal.XF.Infra.Controls
{
    public class IconLabel : Label
    {
        public static readonly string Typeface = "Font-Awesome-5-Free-Regular-400";
        public static readonly string TypefaceFileName = "Font-Awesome-5-Free-Regular-400.otf";

        private string FontFamilyName => $"{TypefaceFileName}#{Typeface}";

        public IconLabel()
        {
            FontFamily = FontFamilyName;
        }

        public IconLabel(string text = null)
        {
            FontFamily = FontFamilyName;
            Text = text;
        }
    }
}
