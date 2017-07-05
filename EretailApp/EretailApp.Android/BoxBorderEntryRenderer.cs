using EretailApp;
using EretailApp.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BoxBorderEntry), typeof(BoxBorderEntryRenderer))]
namespace EretailApp.Droid
{
  public  class BoxBorderEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.editextborder);
            }
        }
    }
}