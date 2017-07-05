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
    public partial class TaxForm : ContentPage
    {
        List<TaxFile> lstTax;
        BusinessLogicViewModel vm;
        //        List<ProductModel> ll = new List<ProductModel>
        //        {
        //              new ProductModel
        //           {
        //        name="A",
        //        Dept="10%",
        //                category="Mens",
        //                Icon="ic_user.png",
        //         },
        //           new ProductModel
        //           {
        //                name="B",
        //                Dept="20%",
        //                category="Mens",
        //                Icon="ic_user.png",

        //           }
        //           ,

        //             new ProductModel
        //           {
        //               name="C",
        //                Dept="30%",
        //                category="Womens",
        //                Icon="ic_user.png",

        //           }
        //             ,
        //                 new ProductModel
        //           {
        //               name=" D",
        //                Dept="40%",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }

        //                     ,
        //                 new ProductModel
        //           {
        //               name=" D",
        //                Dept="40%",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }


        //                     ,
        //                 new ProductModel
        //           {
        //               name=" D",
        //                Dept="40%",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }


        //                     ,
        //                 new ProductModel
        //           {
        //               name=" D",
        //                Dept="40%",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }


        //                     ,
        //                 new ProductModel
        //           {
        //               name=" D",
        //                Dept="40%",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }
        //                 ,
        //                       new ProductModel
        //           {
        //               name="E ",
        //                Dept="50%",
        //                category="Branded Shirts",
        //                Icon="ic_user.png",
        //           }
        //,
        //        };
        public TaxForm()
        {
            InitializeComponent();
            //TaxList.ItemsSource = ll;
            BindingContext = vm = new BusinessLogicViewModel();
            vm.ExecuteLoad_TaxAzure();
            lstTax = new List<TaxFile>();
            lstTax = BusinessLogicViewModel.GetTax().ToList<TaxFile>();

            TaxList.ItemsSource = lstTax;

        }

        public void SearchTaxclick(Object o, TextChangedEventArgs e)
        {
            try {
                //String str = searchTax.Text;
                //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
                //TaxList.ItemsSource = searchresult;

                TaxList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    TaxList.ItemsSource = lstTax;
                else
                    TaxList.ItemsSource = lstTax.Where(i => i.TaxGrpDesc.ToLower().Contains(e.NewTextValue.ToLower()));

                TaxList.EndRefresh();

            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        

        public void AddTax(Object o, EventArgs e)
        {
            // Navigation.PushModalAsync(new AddCategoryForm());
            TaxTitle.Text = "Tax";
            CreateCategory.IsVisible = true;
        }

        private void tax_save_clicked(object sender, EventArgs e)
        {
            try {
                if (String.IsNullOrEmpty(entry_Tax_entry.Text))
                {
                    DisplayAlert("Error", "Enter Tax", "Ok");
                    return;
                }
                else
                {
                    Int64 TaxGrpCodeExists = BusinessLogicViewModel.GetCode("Select TaxGrpCode from TaxFile  Where TaxGrpDesc='" + entry_Tax_entry.Text + "'");
                    if (TaxGrpCodeExists == 0)
                    {
                        Int64 TaxCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(TaxGrpCode as int)),0) as TaxGrpCode from TaxFile");
                        TaxCode++;
                        BusinessLogicViewModel.InsertAddTax(TaxCode, entry_Tax_entry.Text);
                       
                    }
                    entry_Tax_entry.Text = "";
                    CreateCategory.IsVisible = false;
                    
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
}
        }

        private void tax_pop_cancel_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (! String.IsNullOrEmpty(entry_Tax_entry.Text))
                {
                    DisplayAlert("Alert", "Do You Want Clear the Text"+entry_Tax_entry, "Yes","No");
                    return;
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

    }
    }
