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
    public partial class CustomerForm : ContentPage
    {
        //        List<ProductModel> ll = new List<ProductModel>
        //        {
        //              new ProductModel
        //           {
        //        name="Shirt",
        //        Dept="PepiJeans",
        //                category="Mens",
        //                Icon="ic_user.png",
        //         },
        //           new ProductModel
        //           {
        //                name="Jeans",
        //                Dept="PepiJeans",
        //                category="Mens",
        //                Icon="ic_user.png",

        //           }
        //           ,

        //             new ProductModel
        //           {
        //               name="T-Shirt",
        //                Dept="Pan America",
        //                category="Womens",
        //                Icon="ic_user.png",

        //           }
        //             ,
        //                 new ProductModel
        //           {
        //               name=" Round Neck T-Shirt",
        //                Dept="Us Polo",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }
        //                 ,

        //                       new ProductModel
        //           {
        //               name="Gap-TShirt ",
        //                Dept="Lives",
        //                category="Branded Shirts",
        //                Icon="ic_user.png",

        //           }

        //,

        //        };

        BusinessLogicViewModel vm;
        List<CustomerMaster> lstcust;
        public CustomerForm()
        {
            InitializeComponent();
            //CustmorList.ItemsSource = ll;
            BindingContext = vm = new BusinessLogicViewModel();
            vm.ExecuteLoad_CustomerAzure();
            lstcust = new List<CustomerMaster>();
            lstcust = BusinessLogicViewModel.GetCustomer().ToList<CustomerMaster>();

            CustmorList.ItemsSource = lstcust;

        }


        public void searchvalue_TextChanged(Object o, TextChangedEventArgs e)
                    {

                //String str = searchcategory.Text;
                //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
                //categoryList.ItemsSource = searchresult;

                try
                {



                    CustmorList.BeginRefresh();

                    if (string.IsNullOrWhiteSpace(e.NewTextValue))
                        CustmorList.ItemsSource = lstcust;
                    else
                        CustmorList.ItemsSource = lstcust.Where(i => i.Cust_Name.ToLower().Contains(e.NewTextValue.ToLower()));

                    CustmorList.EndRefresh();

                    //IEnumerable<Hierarchy_2> searchresult = lstH2.Where(name1 => name1.Description.Contains(txtH2.Text));
                    //H2List.ItemsSource = searchresult;
                }
                catch (Exception ee)
                {
                    DisplayAlert("Alert", ee.Message, "Ok");
                }
            }

        

        public void AddCustmor(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new AddCustomer());
        }

        private void CustmorList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (CustomerMaster)e.SelectedItem;
             searchvalue.Text = item.Cust_Name.ToString();

        }
    }
}
