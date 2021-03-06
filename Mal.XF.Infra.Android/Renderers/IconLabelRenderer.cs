﻿using Mal.XF.Infra.Android.Renderers;
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
            base.OnElementChanged(e);
            if (e.OldElement != null) return;
            if (e.OldElement != null) return;
            FontProvider.ApplyFont(this.Control);
        }
    }
}