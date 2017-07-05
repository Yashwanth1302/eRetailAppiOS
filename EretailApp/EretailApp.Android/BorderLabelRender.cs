using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using EretailApp.Droid;
using EretailApp;

[assembly: ExportRenderer(typeof(LabelRender), typeof(BorderLabelRender))]
namespace EretailApp.Droid
{
   public  class BorderLabelRender :LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.SetBackgroundResource(Resource.Drawable.mandEntryborder);
            }
        }
    }
}