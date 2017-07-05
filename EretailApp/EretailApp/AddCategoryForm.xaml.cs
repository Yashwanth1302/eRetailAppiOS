using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class AddCategoryForm : ContentPage
    {
        public AddCategoryForm()
        {
            InitializeComponent();
        }
        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
        private void cancel_clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());

        }
    }
}
