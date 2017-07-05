using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace EretailApp
{
    public partial class TransactionsForm : ContentPage
    {

        List<ProductModel> ll = new List<ProductModel>

        {
              new ProductModel
           {
        name="Ean10101",
        Dept="25",
                category="Mens",
                Icon="ic_user.png",
         },
           new ProductModel
           {
                name="Ean10102",
                Dept="30",
                category="Mens",
                Icon="ic_user.png",

           }
           ,

             new ProductModel
           {
               name="Ean10103",
                Dept="40",
                category="Womens",
                Icon="ic_user.png",

           }
             ,
                 new ProductModel
           {
               name="Ean104",
                Dept="50",
                category="Kids",
                Icon="ic_user.png",

           }
                 ,

                       new ProductModel
           {
               name="Ean105 ",
                Dept="60",
                category="Branded Shirts",
                Icon="ic_user.png",

           }

,

        };

        String strSkuCode ;
        String strEANCode ;
        String strQty ;
        String strFreeQty ;
        String strRate;
        String strTax ;
        String strAmount;

        public TransactionsForm()
        {
            InitializeComponent();

            ReturnPicker.Items.Add("Receivings");
            ReturnPicker.Items.Add("Purchase Returns");
            

        }

        public void ChooseReturnPicker(Object o, EventArgs e)
        {

            var name = ReturnPicker.Items[ReturnPicker.SelectedIndex];
        }








        public void btnclick(Object o, EventArgs e)
        {

            string str = searchsku.Text;
            IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
            SkuList.ItemsSource = searchresult;

            //if (str.Equals(""))
            //{ SkuItemCliscked OnSkuItemSelected
            //    ll.Clear();
            //}

        }








        // ean and rate (in Additon ,Edit layout Imple)

        public void SkuItemClilcked(Object o, EventArgs e)
        {
            SkuSL.IsVisible = true;
            Addiconsl.IsVisible = false;
            Minusiconsl.IsVisible = true;

         SkuList.ItemsSource = ll;
        }


        public void SkuItemClilckedMinus(Object o, EventArgs e)
        {
            SkuSL.IsVisible = false;
            Minusiconsl.IsVisible = false;
            Addiconsl.IsVisible = true;

            // SkuList.ItemsSource = ll;
        }




        // Edit Add Ean row info 

        public void EditSkuItemClilcked(Object o, EventArgs e)
        {

            EditSkuSL.IsVisible = true;
            EditEanAddIconsl.IsVisible = false;
            EditEanMinusIconsl.IsVisible = true;
            EditSkuList.ItemsSource = ll;
        }
        public void EditMinusSkuItemClilcked(Object o, EventArgs e)
        {
            EditSkuSL.IsVisible = false;
            EditEanAddIconsl.IsVisible = true;
            EditEanMinusIconsl.IsVisible = false;
        }






        // Rate Add Icon 

        public void RateItemClilcked(Object o, EventArgs e)
        {
          //rateimg.Source = "minusIcon.png";

            RateSL.IsVisible = true;
            RateAddiconsl.IsVisible = false;
            RateMinusiconsl.IsVisible = true;
            RateList.ItemsSource = ll;
        }


        // Rate Minus Icon 
        public void MinusIconrateItemClilcked(Object o, EventArgs e)
        {
            RateSL.IsVisible = false;
            RateAddiconsl.IsVisible = true;
            RateMinusiconsl.IsVisible = false;

        }






        public void EditRateItemClilcked(Object o, EventArgs e)
        {
            EditRateSL.IsVisible = true;
            EditrateAddIconsl.IsVisible = false;
            EditrateMinusIconsl.IsVisible = true;

            EditRateList.ItemsSource = ll;

   }

        // Edit minus Icon 
        public void EditminusRateItemClilcked(Object o, EventArgs e)
        {
            EditRateSL.IsVisible = false;
            EditrateAddIconsl.IsVisible = true;
            EditrateMinusIconsl.IsVisible = false;
        }



        // add details to Listview 
        public void AddIcon(Object o, EventArgs e)
        {

            SkuListAdd.IsVisible = false;
            SkuSL.IsVisible = false;
            MainlistSl.IsVisible = true;
            SkuListEdit.IsVisible = true;



          strSkuCode = entrysku.Text;
           strEANCode = entryEAN.Text;
         strQty = entryQty.Text;
          strFreeQty = entryFreeQty.Text;
          strRate = entryRate.Text;
         strTax = entryTax.Text;
            strAmount = entryAmount.Text;

            Editentrysku.Text = strSkuCode;
            EditentryEAN.Text = strEANCode;
            EditentryQty.Text = strQty;
            EditentryFreeQty.Text = strFreeQty;
            EditentryRate.Text = strRate;
            EditentryTax.Text = strTax;
            EditentryAmount.Text = strAmount;

List<ProductModel> ll = new List<ProductModel>

            {
                  new ProductModel
               { 
        
            Sku =strSkuCode,
              EANCode =strEANCode,
       Qty =strQty,
        FreeQty =strFreeQty,
             Rate =strRate,
            Tax =strTax,
            Amount =strAmount,

             },
                };


            Mainlist.ItemsSource = ll; 
        }




        public void EditIcon(Object o, EventArgs e)
        {

             SkuListAdd.IsVisible = false;
            strSkuCode = Editentrysku.Text;
             strEANCode = EditentryEAN.Text;
           strQty = EditentryQty.Text;
            strFreeQty = EditentryFreeQty.Text;
             strRate = EditentryRate.Text;
           strTax = EditentryTax.Text;
           strAmount = EditentryAmount.Text;

          entrysku.Text = strSkuCode;
          entryEAN.Text = strEANCode;
           entryQty.Text = strQty;
          entryFreeQty.Text = strFreeQty;
          entryRate.Text = strRate;
           entryTax.Text = strTax;
          entryAmount.Text = strAmount;


            List<ProductModel> ll = new List<ProductModel>

            {
                  new ProductModel
               {

            Sku =strSkuCode,
              EANCode =strEANCode,
       Qty =strQty,
        FreeQty =strFreeQty,
             Rate =strRate,
            Tax =strTax,
            Amount =strAmount,

             },
                };


            Mainlist.ItemsSource = ll;
            MainlistSl.IsVisible = true;


        }


        //public void rateimageclicked(Object o, EventArgs e)
        //{


        //    rateimage.Image ="minusIcon.png";


        //}



        public void MainlistAddIcon(Object o, EventArgs e)
        {

            SkuListAdd.IsVisible = true;
            MainlistSl.IsVisible = false;
            SkuListEdit.IsVisible = false;


        }

    public void MainlistDeleteRow(Object o, EventArgs e)
        {
           ll.Clear();
            Mainlist.ItemsSource = ll;
            MainlistSl.IsVisible = false;

               }



        public void AddDeleteIcon(Object o, EventArgs e)
        {
            entrysku.Text="";
            entryEAN.Text = "";
            entryQty.Text = "";
            entryFreeQty.Text = "";
            entryRate.Text = "";
           entryTax.Text = "";
          entryAmount.Text = "";

        }


        public void EditDeleteIcon(Object o, EventArgs e)
        {
            Editentrysku.Text = "";
            EditentryEAN.Text = "";
            EditentryQty.Text = "";
            EditentryFreeQty.Text = "";
            EditentryRate.Text = "";
            EditentryTax.Text = "";
            EditentryAmount.Text = "";

        }





        public void OnSkuItemSelected(Object o, SelectedItemChangedEventArgs e)
        {

            var item = (ProductModel)e.SelectedItem;
            entryEAN.Text=item.name.ToString();
            SkuSL.IsVisible = false;
            Addiconsl.IsVisible = true;
            Minusiconsl.IsVisible = false;

           

        }


        public void OnEditSkuItemSelected(Object o, SelectedItemChangedEventArgs e)
        {

            var item = (ProductModel)e.SelectedItem;
            EditentryEAN.Text = item.name.ToString();
            EditSkuSL.IsVisible = false;
            EditEanAddIconsl.IsVisible = true;
            EditEanMinusIconsl.IsVisible = false;



        }



        // rate listview 

        public void OnRateItemSelected(Object o, SelectedItemChangedEventArgs e)
        {

            var item = (ProductModel)e.SelectedItem;
            entryRate.Text = item.Dept.ToString();
            RateSL.IsVisible = false;
            RateAddiconsl.IsVisible = true;
            RateMinusiconsl.IsVisible = false;



        }
        public void OnEditRateItemSelected(Object o, SelectedItemChangedEventArgs e)
        {

            var item = (ProductModel)e.SelectedItem;
            EditentryRate.Text = item.Dept.ToString();
            EditRateSL.IsVisible = false;
            EditrateAddIconsl.IsVisible =true;
           EditrateMinusIconsl.IsVisible = false;

        }
        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
        private void cancel_clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
    }
}
