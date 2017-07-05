using EretailApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class AddSupplierForm : ContentPage
    {
        public AddSupplierForm()
        {
            InitializeComponent();
        }

        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        private void btn_vendoraddress_clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(et_vendercode.Text))
            {
                et_vendercode.Focus();
                DisplayAlert("Alert", "Please Enter Vendor Code ", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(et_vendorname.Text))
            {
                et_vendorname.Focus();
                DisplayAlert("Alert", "Please Enter Employee Name ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_contactperson.Text))
            {
                et_contactperson.Focus();
                DisplayAlert("Alert", "Please Enter Contact Person ", "Ok"); return;
            }

            //
            if (String.IsNullOrEmpty(et_contactnumer.Text))
            {
                et_contactnumer.Focus(); DisplayAlert("Alert", "Please Enter Contact Number ", "Ok"); return;
            }
            //address2, string country, string state, string city, string zip, string email)
            if (String.IsNullOrEmpty(et_address1.Text))
            {
                et_address1.Focus(); DisplayAlert("Alert", "Please Enter Address1 ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_address2.Text))
            {
                et_address2.Focus(); DisplayAlert("Alert", "Please Enter Address2 ", "Ok"); return;
            }
            //if (String.IsNullOrEmpty(et_country.Text))
            //{
            //    et_country.Focus(); DisplayAlert("Alert", "Please Enter Country ", "Ok"); return;
            //}
            //if (String.IsNullOrEmpty(et_state.Text))
            //{
            //    et_state.Focus(); DisplayAlert("Alert", "Please Enter State ", "Ok"); return;
            //}
            //if (String.IsNullOrEmpty(et_city.Text))
            //{
            //    et_city.Focus(); DisplayAlert("Alert", "Please Enter City ", "Ok"); return;
            //}

            if (String.IsNullOrEmpty(et_country.Text))
            {
                et_country.Focus(); DisplayAlert("Alert", "Please Enter Country ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_state.Text))
            {
                et_state.Focus(); DisplayAlert("Alert", "Please Enter State", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_city.Text))
            {
                et_city.Focus(); DisplayAlert("Alert", "Please Enter City", "Ok"); return;
            }


            if (String.IsNullOrEmpty(et_zip.Text))
            {
                et_zip.Focus(); DisplayAlert("Alert", "Please Enter Zip ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_gst.Text))
            {
                et_gst.Focus(); DisplayAlert("Alert", "Please Enter GST ", "Ok"); return;
            }

            if (String.IsNullOrEmpty(et_discount.Text))
            {
                et_discount.Focus(); DisplayAlert("Alert", "Please Enter Discount ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_vendor_emailid.Text))
            {
                et_vendor_emailid.Focus(); DisplayAlert("Alert", "Please Enter EmailId ", "Ok"); return;
            }
            BusinessLogicViewModel.InsertAddVendorAddress(Convert.ToInt32(et_vendercode.Text), et_contactnumer.Text, et_address1.Text,et_address2.Text,et_state.Text,et_country.Text,et_vendor_emailid.Text, et_zip.Text);
           
    }
        private void cancel_clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());

        }
    }
}
