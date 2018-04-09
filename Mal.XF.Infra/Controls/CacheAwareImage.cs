using System;
using Xamarin.Forms;

namespace Mal.XF.Infra.Controls
{
    public class CacheAwareImage : Image
    {
        public static readonly BindableProperty ImageUrlProperty = BindableProperty.CreateAttached(
            nameof(CacheAwareImage.ImageUrl),
            typeof(string),
            typeof(CacheAwareImage),
            null, propertyChanged: OnImageUrlChanged);

        public string ImageUrl
        {
            get { return (string)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        public static readonly BindableProperty CacheValidityProperty = BindableProperty.CreateAttached(
            nameof(CacheAwareImage.CacheValidity),
            typeof(TimeSpan),
            typeof(CacheAwareImage),
            TimeSpan.FromMinutes(10), propertyChanged: OnCacheValidityChanged);

        public TimeSpan CacheValidity
        {
            get { return (TimeSpan)GetValue(CacheValidityProperty); }
            set { SetValue(CacheValidityProperty, value); }
        }

        private static void OnImageUrlChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CacheAwareImage)bindable).SetImageSource();
        }

        private static void OnCacheValidityChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((CacheAwareImage)bindable).SetImageSource();
        }

        private void SetImageSource()
        {
            Uri imageUri;
            if (Uri.TryCreate(this.ImageUrl, UriKind.RelativeOrAbsolute, out imageUri))
            {
                this.Source = new UriImageSource
                {
                    Uri = imageUri,
                    CachingEnabled = true,
                    CacheValidity = this.CacheValidity
                };
            }
        }
    }
}