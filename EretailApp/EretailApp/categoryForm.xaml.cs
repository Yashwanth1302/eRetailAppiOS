using EretailApp.Model;
using EretailApp.ViewModel;
using EretailApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class categoryForm : ContentPage
    {
        List<Hierarchy_2> lstH2;
        //List<VendorMaster> lstvendor;
        //List<UOMeasurement> lstUom;

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

        public categoryForm()
        {
            InitializeComponent();
            // categoryList.ItemsSource = ll;


            BindingContext = vm = new BusinessLogicViewModel();
            vm.ExecuteLoadH2_CategeoryAzure();

            lstH2 = new List<Hierarchy_2>();
            //lstvendor = new List<VendorMaster>();
            //lstUom = new List<UOMeasurement>();
            lstH2 = BusinessLogicViewModel.GetHierarchy_2().ToList<Hierarchy_2>();
            categoryList.ItemsSource = lstH2;

            //VendorList.ItemsSource = lstvendor;
            //UomList.ItemsSource = lstUom;
        }


        public void SearchCategoryclick(Object o, TextChangedEventArgs e)
        {

            //String str = searchcategory.Text;
            //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
            //categoryList.ItemsSource = searchresult;

            try
            {



                categoryList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    categoryList.ItemsSource = lstH2;
                else
                    categoryList.ItemsSource = lstH2.Where(i => i.Description.ToLower().Contains(e.NewTextValue.ToLower()));

                categoryList.EndRefresh();

                //IEnumerable<Hierarchy_2> searchresult = lstH2.Where(name1 => name1.Description.Contains(txtH2.Text));
                //H2List.ItemsSource = searchresult;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }



        public void ADDCategory(Object o, EventArgs e)
        {
            // Navigation.PushModalAsync(new AddCategoryForm());
            categoryTitle.Text = "Category";
            CreateCategory.IsVisible = true;
        }


        public void ADDCategory1(Object o, EventArgs e)
        {
            // Navigation.PushModalAsync(new AddCategoryForm());
            //CreateCategory.IsVisible = true;
        }

        private void categeory_save_clicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(entry_categeory_entry.Text))
                {
                    DisplayAlert("Error", "Enter Categeory", "Ok");
                    return;
                }
                else
                {
                    Int64 H2Code = 0;
                    Int64 H2Exists = BusinessLogicViewModel.GetCode("Select H2_Code from Hierarchy_2 Where Description='" + entry_categeory_entry.Text + "'");
                    if (H2Exists == 0)
                    {
                        H2Code = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(H2_Code as int)),0) as H2_Code from Hierarchy_2");
                        H2Code++;
                        BusinessLogicViewModel.InsertAddH2(H2Code, entry_categeory_entry.Text);
                    }
                    entry_categeory_entry.Text = "";

                    CreateCategory.IsVisible = false;
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void cancel_clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());

        }
        private void categeory_pop_cancel_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(entry_categeory_entry.Text))
                {
                    DisplayAlert("Alert", "Do You Want Clear the Text" + entry_categeory_entry, "Yes", "No");
                    return;
                }

            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
    }
}