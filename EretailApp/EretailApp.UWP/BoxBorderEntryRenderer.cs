using EretailApp;
using EretailApp.UWP;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(BoxBorderEntry), typeof(BoxBorderEntryRenderer))]
namespace EretailApp.UWP
{
    class BoxBorderEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new SolidColorBrush(Colors.White);

                Control.BackgroundFocusBrush = new SolidColorBrush(Colors.DarkGray);
                Control.BorderBrush = new SolidColorBrush(Colors.LightGray);
                Control.BorderThickness = new Windows.UI.Xaml.Thickness(1);
                Control.ForegroundFocusBrush = new SolidColorBrush(Colors.DarkGray);
                Control.Foreground = new SolidColorBrush(Colors.DarkGray);
            }
        }
    }
}