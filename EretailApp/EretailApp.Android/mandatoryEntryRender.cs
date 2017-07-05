using EretailApp;
using EretailApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(mandatoryEntry), typeof(mandatoryEntryRender))]
namespace EretailApp.Droid
{
    class mandatoryEntryRender: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.mandEntryborder);
            }
        }
    }
}