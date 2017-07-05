using EretailApp.Model;
using EretailApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class SupplierFormxaml : ContentPage
    {
        //        List<ProductModel> ll = new List<ProductModel>
        //        {
        //              new ProductModel
        //           {
        //        name="Shirt",
        //        Dept="InActive",
        //                category="Mens",
        //                Icon="ic_user.png",
        //         },
        //           new ProductModel
        //           {
        //                name="Jeans",
        //                Dept="InActive",
        //                category="Active",
        //                Icon="ic_user.png",

        //           }
        //           ,

        //             new ProductModel
        //           {
        //               name="T-Shirt",
        //                Dept="Active",
        //                category="Womens",
        //                Icon="ic_user.png",

        //           }
        //             ,
        //                 new ProductModel
        //           {
        //               name=" Round Neck T-Shirt",
        //                Dept="Active",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }
        //                 ,

        //                       new ProductModel
        //           {
        //               name="Gap-TShirt ",
        //                Dept="InActive",
        //                category="Branded Shirts",
        //                Icon="ic_user.png",

        //           }

        //,

        //        };


        BusinessLogicViewModel vm;
        List<VendorAddresse> lstvendoraddress;
        public SupplierFormxaml()
        {
            InitializeComponent();

            BindingContext = vm = new BusinessLogicViewModel();
            vm.ExecuteLoad_VendorAddressAzure();
            lstvendoraddress = new List<VendorAddresse>();
            lstvendoraddress = BusinessLogicViewModel.GetVendorAddress().ToList<VendorAddresse>();

            SuplierList.ItemsSource = lstvendoraddress;

        }
        //  SuplierList.ItemsSource = ll;
    
        public void btnclick(Object o, EventArgs e)
        {

            //String str = searchvalue.Text;
            //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
            //SuplierList.ItemsSource = searchresult;

            ////if (str.Equals(""))
            ////{
            ////    ll.Clear();
            ////}

        }

        public void AddSupplier(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new AddSupplierForm());
        }

    }
}
