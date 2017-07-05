using EretailApp;
using EretailApp.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(RegulerLabelRender), typeof(RegulerLabel))]
namespace EretailApp.iOS
{
    public class RegulerLabel : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.TextColor = UIColor.DarkGray;
                Control.Layer.BorderColor = UIColor.LightGray.CGColor;
                Control.BackgroundColor = UIColor.Blue;
                Control.Layer.BorderWidth = 1.0f;
            }
        }
    }
}
