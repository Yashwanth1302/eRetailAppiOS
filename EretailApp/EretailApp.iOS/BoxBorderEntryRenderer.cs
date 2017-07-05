using EretailApp;
using EretailApp.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BoxBorderEntry), typeof(BoxBorderEntryRenderer))]
namespace EretailApp.iOS
{
    class BoxBorderEntryRenderer : EntryRenderer
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