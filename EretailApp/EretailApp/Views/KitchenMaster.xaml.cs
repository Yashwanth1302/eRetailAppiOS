using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp.Views
{
    public partial class KitchenMaster : ContentPage
    {
        List<ProductModel> ll = new List<ProductModel>
        {
              new ProductModel
           {
        name="k1",
    
         },
           new ProductModel
           {
                name="K2",
             

           }
           ,

             new ProductModel
           {
               name="K3",
            

           }
             ,
                 new ProductModel
           {
               name=" K4",
           

           }
                 ,

                       new ProductModel
           {
               name="K5",
             

           }

,

        };



        public KitchenMaster()
        {
            InitializeComponent();
            KitchenList.ItemsSource = ll;
        }


        public void SearchBrandclick(Object o, EventArgs e)
        {

            String str = searchKitchen.Text;
            IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
            KitchenList.ItemsSource = searchresult;



        }

        public void AddBrand(Object o, EventArgs e)
        {
            // Navigation.PushModalAsync(new AddCategoryForm());
            CreateKitchen.IsVisible = true;
            //BrandTitle.Text = "Brand";
        }



    }
}
