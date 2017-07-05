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
    public partial class BrandForm : ContentPage
    {
        List<Brand> lstbrand;


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

        public BrandForm()
        {
            InitializeComponent();
            //BrandList.ItemsSource = ll;
            BindingContext = vm = new BusinessLogicViewModel();
            vm.ExecuteLoadBrandAzure();
            lstbrand = new List<Brand>();
            lstbrand = BusinessLogicViewModel.GetBrand().ToList<Brand>();
            BrandList.ItemsSource = lstbrand;
        }

        public void SearchBrandclick(Object o, TextChangedEventArgs e)
        {

            //String str = searchBrand.Text;
            //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
            //BrandList.ItemsSource = searchresult;
            try
            {
                BrandList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    BrandList.ItemsSource = lstbrand;
                else
                    BrandList.ItemsSource = lstbrand.Where(i => i.BrandDesc.ToLower().Contains(e.NewTextValue.ToLower()));

                BrandList.EndRefresh();


                /* */


            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }


        public void AddBrand(Object o, EventArgs e)
        {
            // Navigation.PushModalAsync(new AddCategoryForm());
            CreateCategory.IsVisible = true;
            BrandTitle.Text = "Brand";
        }

        private void brand_save_clicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(entry_Brand_entry.Text))
                {
                    DisplayAlert("Error", "Enter Brand", "Ok");
                    return;
                }
                else
                {
                    Int64 BrandCodeExists = BusinessLogicViewModel.GetCode("Select BrandCode from Brand  Where BrandDesc='" + entry_Brand_entry.Text + "'");
                    if (BrandCodeExists == 0)
                    {
                        Int64 BrandCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(BrandCode as int)),0) as BrandCode from Brand");
                        BrandCode++;
                        BusinessLogicViewModel.InsertAddBrand(BrandCode, entry_Brand_entry.Text);

                    }
                               

                    entry_Brand_entry.Text = "";
                    CreateCategory.IsVisible = false;
                    BindingContext = vm = new BusinessLogicViewModel();

                    vm.ExecuteLoadBrandAzure();
                    lstbrand = new List<Brand>();
                    lstbrand = BusinessLogicViewModel.GetBrand().ToList<Brand>();
                    BrandList.ItemsSource = lstbrand;

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
        private void brand_pop_cancel_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(entry_Brand_entry.Text))
                {
                    DisplayAlert("Alert", "Do You Want Clear the Text" + entry_Brand_entry, "Yes", "No");
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