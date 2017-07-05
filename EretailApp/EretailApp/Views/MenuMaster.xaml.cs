using EretailApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class MenuMaster : ContentPage
    {
        List<ProductModel> ll = new List<ProductModel>
        {
           
      new ProductModel
           {
               name="Veg Birayani",
                Dept="Meals",
                category="Spicy",
                Icon="ic_user.png",

           }
             ,
                 new ProductModel
           {
               name=" Kara",
                Dept="Sancks",
                category="Spicy",
                Icon="ic_user.png",

           }
                 ,

                       new ProductModel
           {
               name="Iddly ",
                Dept="Tiffens",
                category="Spicy",
                Icon="ic_user.png",

           }

,

        };
        public MenuMaster()
        {
            InitializeComponent();
            KitchenList.ItemsSource = ll;

            Mainpicker.Items.Add("Veg Birayani");
            Mainpicker.Items.Add("Kara");
            Mainpicker.Items.Add("Iddly");


            Deptpicker.Items.Add("Meals");
            Deptpicker.Items.Add("Sancks");
            Deptpicker.Items.Add("Tiffens");
          
        }
        private void onselecteditem(Object sender, EventArgs e)
        {

            var name = Mainpicker.Items[Mainpicker.SelectedIndex];
            //  DisplayAlert(name, "SelectedItem", "Okay");
            if (!name.Equals("") || !searchvalue.Text.Equals(""))
            {
                String str = searchvalue.Text;
                //if (!str.Equals(""))
                //{
                //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str) || name1.name.Contains(name));
                //mylistvi.ItemsSource = searchresult;
                // }

            }
        }

        private void Deptonselecteditem(Object sender, EventArgs e)
        {

            var name = Deptpicker.Items[Deptpicker.SelectedIndex];
            //DisplayAlert(name, "SelectedItem", "Okay");

            //if (!name.Equals(""))
            //{
            //    String str = searchvalue.Text;
            //    IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str) || name1.name.Contains(name));
            //    mylistvi.ItemsSource = searchresult;
            //}



        }


        public void btnclick(Object o, EventArgs e)
        {

            String str = searchvalue.Text;
            IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
            KitchenList.ItemsSource = searchresult;

            //if (str.Equals(""))
            //{
            //    ll.Clear();
            //}

        }

        //public void back(Object o, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new MainPage());
        //}

        public void AddMenuMaster(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MenuMasterConfig());
        }
        //public void AddProductTwo(Object o, EventArgs e)
        //{
        //    Navigation.PushModalAsync(new ProductConfig());
        //}
    }

}
