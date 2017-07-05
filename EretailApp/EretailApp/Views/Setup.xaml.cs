using EretailApp.ViewModel;
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
    public partial class Setup : ContentPage
    {
    

        MasterViewModel vm;
        List<ProductModel> lm = new List<ProductModel>();
        List<ProductModel> ll = new List<ProductModel>
        {
            new ProductModel
           {
        name="Telugu",
        PaymentMode="Cash",
        HourlySales="1",
        DayendSales="1",


         },
           new ProductModel
           {
                name="Jeans",
                 PaymentMode="Card",
                    HourlySales="2",
        DayendSales="2",


           }
           ,

             new ProductModel
           {
               name="English",
                PaymentMode="Credit",
                             HourlySales="3",
        DayendSales="3"

           }
             ,
                 new ProductModel
           {
               name="Hindi",
                PaymentMode="Cheque",
                             HourlySales="4",
        DayendSales="4"


           }
                 ,

                       new ProductModel
           {
               name="Gap-TShirt ",
                PaymentMode="Cash",
               HourlySales="5",
             DayendSales="5"

           }

,

        };



        public Setup()
        {
            this.BindingContext = new MainPageViewModel();
            InitializeComponent();

            BindingContext = vm = new MasterViewModel();

            BindingContext = new SettingsViewModel();

            // languages 
            LangPicker.Items.Add("Telugu");
            LangPicker.Items.Add("English");
            LangPicker.Items.Add("Hindi");

            // paymentModes

            PaymentModePicker.Items.Add("Cash");
            PaymentModePicker.Items.Add("Card");
            PaymentModePicker.Items.Add("Credit");
            PaymentModePicker.Items.Add("Cheque");

        }



        //public void onselecteditem(object o, EventArgs e)
        //{

        //    var name = picklng.Items[picklng.SelectedIndex];
           


        //}




        public void btnSavesettings(Object o, EventArgs e)
        {

         if (swdept.IsToggled == true)
            {
                MasterViewModel.deptvalue = true;
            }
            else
            {
                MasterViewModel.deptvalue = false;
            
            }
            if (swcatg.IsToggled == true)
            {
                MasterViewModel.Catgvalue = true;
            }

            else
            {
                MasterViewModel.Catgvalue = false;

            }

            if (swbrand.IsToggled == true)
            {
                MasterViewModel.Brandvalue = true;
            }
            else
            {
                MasterViewModel.Brandvalue = false;

            }
            if (swUom.IsToggled == true)
            {
                MasterViewModel.UomValue = true;
            }
            else
            {
                MasterViewModel.UomValue = false;

            }
            if (swTax.IsToggled == true)
            {
                MasterViewModel.TaxValue = true;
            }
            else
            {
                MasterViewModel.TaxValue = false;

            }
            if (swdept.IsToggled == false && swcatg.IsToggled==false)
            {
                MasterViewModel.Hgvalue = false;
            }
            else
            {
                MasterViewModel.Hgvalue = true;

            }
            if (swMarkup.IsToggled == false)
            {
                MasterViewModel.MarkUpvalue = false;
            }
            else
            {
                MasterViewModel.MarkUpvalue = true;

            }



        }


        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
            // LangList.ItemsSource = ll;
        }


        public void ChooseLang(Object o, EventArgs e)
        {

            var language = LangPicker.Items[LangPicker.SelectedIndex];
        }


        //public void tgdept(Object o, ToggledEventArgs te) {
        //    if (swdept.IsToggled==true)
        //    {
        //        MasterViewModel.deptvalue=true;
                
        //    }
        //    else 
        //    {
        //        MasterViewModel.deptvalue=false;
                
        //    }
        //}


        public void swcard(Object o, ToggledEventArgs e)
        {


            if (e.Value.ToString().Equals("True"))
            {
                //swcard.Text = "ON";



            }

            else
            {
                //swcard.Text = "OFF";
            }

        }


      //  public void btnpayment(Object o, EventArgs e)
      //  {
      //      PaymentList.ItemsSource = ll;
      //      selectPaymentList.ItemsSource = lm;
      //      paymentlistsl.IsVisible = true;
      //      selectpaymentlistsl.IsVisible = false;
       
      //  }

      //  public void OnPaymentModeSelected(Object o, SelectedItemChangedEventArgs e)
      //  {


      //      var item = (ProductModel)e.SelectedItem;
      //     // paybtn.Text = item.PaymentMode.ToString();
      //      //item.IsOwned.ToString();
           
      //      paymentlistsl.IsVisible = false;

      //}

      //public void savepaylist(Object o, EventArgs e)
      //  {
      //      lm.Clear();
           
      //      PaymentList.ItemsSource = ll;
      //      foreach (ProductModel pm in ll)
      //      {
      //lm.Add(pm);
      //    }
           
      //      selectPaymentList.ItemsSource = lm;

      //      selectpaymentlistsl.IsVisible = true;
      //      paymentlistsl.IsVisible = false;


      //  }



        public void OnHrItemSelected(Object o, SelectedItemChangedEventArgs e)
        {

            var item = (ProductModel)e.SelectedItem;
            entryHr.Text = item.HourlySales.ToString();
            HrlistSL.IsVisible = false;
            HrAddiconsl.IsVisible = true;
            HrMinusiconsl.IsVisible = false;
 }


        public void HrItemClilcked(Object o, SelectedItemChangedEventArgs e)
        {
            HrlistSL.IsVisible = true;
            HrAddiconsl.IsVisible = false;
            HrMinusiconsl.IsVisible = true;

            HrList.ItemsSource = ll;
        }

        public void HrItemClilckedMinus(Object o, SelectedItemChangedEventArgs e)
        {
            HrlistSL.IsVisible = false;
            HrAddiconsl.IsVisible = true;
            HrMinusiconsl.IsVisible = false;

        }

        public void btnclick(Object o, EventArgs e)
        {

            string str = searchHr.Text;
            IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.HourlySales.Contains(str));
            HrList.ItemsSource = searchresult;

          

        }






        public void OnDayEndItemSelected(Object o, SelectedItemChangedEventArgs e)
        {

            var item = (ProductModel)e.SelectedItem;
            entryDayEnd.Text = item.DayendSales.ToString();
            DayEndlistSL.IsVisible = false;
            DayEndAddiconsl.IsVisible = true;
            DayEndMinusiconsl.IsVisible = false;
        }


        public void DayEndItemClilcked(Object o, SelectedItemChangedEventArgs e)
        {
            DayEndlistSL.IsVisible = true;
            DayEndAddiconsl.IsVisible = false;
            DayEndMinusiconsl.IsVisible = true;

            DayEndList.ItemsSource = ll;
        }

        public void DayEndItemClilckedMinus(Object o, SelectedItemChangedEventArgs e)
        {
            DayEndlistSL.IsVisible = false;
            DayEndAddiconsl.IsVisible = true;
            DayEndMinusiconsl.IsVisible = false;

        }

        public void btnDayEndclick(Object o, EventArgs e)
        {

            string str = searchHr.Text;
            IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.DayendSales.Contains(str));
            DayEndList.ItemsSource = searchresult;



        }










        public void ChoosePayment(Object o, EventArgs e)
        {

           

               var payment = PaymentModePicker.Items[PaymentModePicker.SelectedIndex];
        }

        void EnableSave(object sender, ToggledEventArgs e)
        {

            //  if (e.Value.ToString().Equals("True"))
            //    {
            //        swcard.Text = "ON";


            //    }
            //    else
            //    {
            //        swcard.Text = "OFF";
            //    }



        }



    }
}