using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp.Views
{
    public partial class MenuMasterConfig : ContentPage
    {
        public MenuMasterConfig()
        {
            InitializeComponent();
            
        }

        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }


        public void SP(Object o, EventArgs e)
        {
            SpCv.IsVisible = true;
            

        }


        public void CancelSp(Object o, EventArgs e)
        {
            SpCv.IsVisible = false;


        }

        public void SaveSp(Object o, EventArgs e)
        {
            SpCv.IsVisible = false;


        }




    }
}
