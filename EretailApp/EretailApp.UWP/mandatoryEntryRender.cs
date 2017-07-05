using EretailApp;
using EretailApp.UWP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(mandatoryEntry), typeof(mandatoryEntryRender))]
namespace EretailApp.UWP
{
    class mandatoryEntryRender : EntryRenderer
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
