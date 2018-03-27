using Xamarin.Forms;

namespace Mal.XF.Infra.Behaviors
{
    public static class ResponsiveGrid
    {
        public static readonly BindableProperty RowProperty = BindableProperty.CreateAttached(
            "Row",
            typeof(int),
            typeof(ResponsiveGrid),
            0);

        public static void SetRow(BindableObject element, int value)
        {
            element.SetValue(RowProperty, value);
        }

        public static int GetRow(BindableObject element)
        {
            return (int)element.GetValue(RowProperty);
        }

        public static readonly BindableProperty ExtraSmallProperty = BindableProperty.CreateAttached(
            "ExtraSmall",
            typeof(int?),
            typeof(ResponsiveGrid),
            null);

        public static void SetExtraSmall(BindableObject element, int? value)
        {
            element.SetValue(ExtraSmallProperty, value);
        }

        public static int? GetExtraSmall(BindableObject element)
        {
            return (int?)element.GetValue(ExtraSmallProperty);
        }

        public static readonly BindableProperty SmallProperty = BindableProperty.CreateAttached(
            "Small",
            typeof(int?),
            typeof(ResponsiveGrid),
            null);
        public static void SetSmall(BindableObject element, int? value)
        {
            element.SetValue(SmallProperty, value);
        }

        public static int? GetSmall(BindableObject element)
        {
            return (int?)element.GetValue(SmallProperty);
        }

        public static readonly BindableProperty MediumProperty = BindableProperty.CreateAttached(
            "Medium",
            typeof(int?),
            typeof(ResponsiveGrid),
            null);

        public static void SetMedium(BindableObject element, int? value)
        {
            element.SetValue(MediumProperty, value);
        }
        public static int? GetMedium(BindableObject element)
        {
            return (int?)element.GetValue(MediumProperty);
        }

        public static readonly BindableProperty LargeProperty = BindableProperty.CreateAttached(
            "Large",
            typeof(int?),
            typeof(ResponsiveGrid),
            null);

        public static void SetLarge(BindableObject element, int? value)
        {
            element.SetValue(LargeProperty, value);
        }
        public static int? GetLarge(BindableObject element)
        {
            return (int?)element.GetValue(LargeProperty);
        }
    }
}