using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp.Views
{
    public partial class CombiMaster : ContentPage
    {
      //  string SCombiCode, SCombiName, SCombiQty, SCombiPrice;
      //  int total = 0;

        List<ProductModel> ll = new List<ProductModel>
        {
              new ProductModel
           {
        CombiCode="oo1",
        CombiPrice="100",
             
         },
           new ProductModel
           {
                 CombiCode="oo2",
                 CombiPrice="200",

           }
           ,

             new ProductModel
           {
                         CombiCode="oo3",
                         CombiPrice="300",


           }
             ,
}; //  private int buttonclick;

        public CombiMaster()
        {
            InitializeComponent();
            CombiList.ItemsSource = ll;


        }

     


    public void SearchCombiclick(Object o, EventArgs e)
        {

            String str = searchCombi.Text;
            IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.CombiCode.Contains(str));
            CombiList.ItemsSource = searchresult;



        }



     public   void  popup(object sender, ToggledEventArgs e)
        {
            //switc.Text = "Switch is" + e.Value.ToString();
            if (e.Value.ToString().Equals("True"))
            {
            

              CombiCV.IsVisible = true;
              

            }
            else
            {
           CombiCV.IsVisible = false;
            }
        }

        public void CancelCombi(Object o, EventArgs e)
        {
            CombiCV.IsVisible = false;
            popupToggle.IsToggled = false;
}
        public void SaveCombi(Object o, EventArgs e)
        {
            CombiCV.IsVisible = false;
            popupToggle.IsToggled = false;

        }

        public  void AddIconCombiItemclicked(Object o, EventArgs e)
        {
          CombiListSL.IsVisible = true;
            ll.Clear();
          {
                ll.Add(new ProductModel
                {
                    CombiCode = entryCombiCode.Text,
                    CombiName = entryCombiName.Text,
                    CombiQty = entryCombiQty.Text,
                });

            }
        CombList.ItemsSource = ll;


        }
 }
}
