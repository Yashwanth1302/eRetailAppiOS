using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EretailApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        List<Productlist> ll = new List<Productlist>
        {
            new Productlist
            {
               ProductName="Product",
               Image="arrow.png"

            },
            new Productlist
            {

               ProductName="Categeory",
               Image="arrow.png"
            },
            new Productlist
            {

               ProductName="Department",
               Image="arrow.png"
            },
           new Productlist
            {

               ProductName="Brand",
               Image="arrow.png"
            },
          new Productlist
            {

               ProductName="Supplier",
               Image="arrow.png"
            },
          new Productlist
            {

               ProductName="Tax",
               Image="arrow.png"
          },
          new Productlist
            {
               ProductName="Receving/Returns",
               Image="arrow.png"
            },

        };



        public Products()
        {
            InitializeComponent();
            productlist.ItemsSource = ll;
        }
    }

}