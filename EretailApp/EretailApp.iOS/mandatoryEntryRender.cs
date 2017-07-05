using EretailApp;
using EretailApp.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(mandatoryEntry), typeof(mandatoryEntryRender))]
namespace EretailApp.iOS
{
    class mandatoryEntryRender : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextColor = UIColor.DarkGray;
                Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                Control.Layer.BorderWidth = 1.0f;
            }
        }
    }
}