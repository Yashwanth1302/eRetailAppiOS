using EretailApp.Model;
using EretailApp.ViewModel;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class ProductDetails : ContentPage
    {
        List<SkuMaster> listsku;
        List<PluMasterPrices> listplu;
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

        public ProductDetails()
        {
            InitializeComponent();
            
            //mylistvi.ItemsSource = ll;
            BindingContext = vm = new BusinessLogicViewModel();



            vm.ExecuteLoadCommandAsync();
            listsku = new List<SkuMaster>();
           // listplu = new List<PluMasterPrices>();

            Deptpicker.ItemsSource = BusinessLogicViewModel.GetHierarchy_1().ToList<Hierarchy_1>();
            Catgpicker.ItemsSource = BusinessLogicViewModel.GetHierarchy_2().ToList<Hierarchy_2>();
            listsku = BusinessLogicViewModel.GetSkumaster().ToList<SkuMaster>();
           // listplu = BusinessLogicViewModel.GetPlumaster().ToList<PluMasterPrices>();
            Productlistt.ItemsSource = listsku;
            //lstH2 = BusinessLogicViewModel.GetHierarchy_2().ToList<Hierarchy_2>();

        }

        private void onselecteditem(Object sender, EventArgs e)
        {

            var name = Catgpicker.Items[Catgpicker.SelectedIndex];
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


        public void selectedItem(Object o, TextChangedEventArgs e)
        {

            String str = searchpickItem.Text;

            String seleted = SelectionPicker.Items[SelectionPicker.SelectedIndex];


            if (seleted.Equals("SkuDescription"))
            {



                Productlistt.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    Productlistt.ItemsSource = listsku;
                else
                    Productlistt.ItemsSource = listsku.Where(i => i.SkuCode.ToLower().Contains(e.NewTextValue.ToLower()));

                Productlistt.EndRefresh();


            }
            else if (seleted.Equals("SKUShortName"))
            {


                Productlistt.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    Productlistt.ItemsSource = listsku;
                else
                    Productlistt.ItemsSource = listsku.Where(i => i.SKUShortName.ToLower().Contains(e.NewTextValue.ToLower()));

                Productlistt.EndRefresh();
            }
            else if (seleted.Equals("SkuType"))
            {
                Productlistt.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    Productlistt.ItemsSource = listsku;
                else
                    Productlistt.ItemsSource = listsku.Where(i => i.SkuType.ToLower().Contains(e.NewTextValue.ToLower()));
                Productlistt.EndRefresh();

            }


        }


        private void Deptonselecteditem(Object sender, EventArgs e)
        {

            //var name = Deptpicker.Items[Deptpicker.SelectedIndex];
            //ListViewSearch(new ProductModel(), mylistvi, searchvalue.Text, "", "");
            //var item = (Hierarchy_1)e.[Deptpicker.SelectedIndex];
            //txtH1.Text = item.H1_Code.ToString();
            //DisplayAlert(name, "SelectedItem", "Okay");

            //if (!name.Equals(""))
            //{
            //    String str = searchvalue.Text;
            //    IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str) || name1.name.Contains(name));
            //    mylistvi.ItemsSource = searchresult;
            //}
        }


        public void SearchProductDetails(Object o, TextChangedEventArgs e)
        {
            //String str = searchvalue.Text;
            //String dpt = Deptpicker.Items[Deptpicker.SelectedIndex];
            //String catg = Catgpicker.Items[Catgpicker.SelectedIndex];
            //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str) || name1.Dept.Contains(dpt) || name1.category.Contains(catg));
            //mylistvi.ItemsSource = searchresult;  



            try
            {
                Productlistt.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    Productlistt.ItemsSource = listsku;
                else
                    Productlistt.ItemsSource = listsku.Where(i => i.SkuCode.ToLower().Contains(e.NewTextValue.ToLower()) || i.SKUShortName.ToLower().Contains(e.NewTextValue.ToLower()) 
                    || i.SkuType.ToLower().Contains(e.NewTextValue.ToLower()));

                Productlistt.EndRefresh();
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }

        }        
        public void AddProduct(Object o, EventArgs e)
        {
            BindingContext = new SettingsViewModel();
            Navigation.PushModalAsync(new productMasterConfig());            
        }
        public void AlertMessage( Exception e)
        {
            DisplayAlert("Alert", e.Message, "Ok");
        }

        public void Productlistt_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (SkuMaster)e.SelectedItem;
                // searchvalue.Text = item.SKUShortName.ToString();
                BusinessLogicViewModel.ListItemValue = item.SkuCode.Trim().ToString();
                if (BusinessLogicViewModel.ListItemValue.Equals(item.SkuCode.Trim().ToString()))
                {
                     Navigation.PushModalAsync(new productMasterConfig());
                }
                else
                {

                }

                //if (entryUom.Text != "")
                //{
                //    UomCv.IsVisible = false;
                //}
            }
            catch (Exception ee)
            {
                // DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

       }

}

