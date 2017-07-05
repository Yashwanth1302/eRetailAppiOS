using EretailApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class AddEmpForm : ContentPage
    {
        public AddEmpForm()
        {
            InitializeComponent();

        }
        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }
        private void cancel_clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());

        }
        private void Btn_Emp_Save_clicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(et_emp_code.Text))
            {
                et_emp_code.Focus();
                DisplayAlert("Alert", "Please Enter Employee Code ", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(et_emp_name.Text))
            {
                et_emp_name.Focus();
                DisplayAlert("Alert", "Please Enter Employee Name ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_contact_person.Text))
            {
                et_contact_person.Focus();
                DisplayAlert("Alert", "Please Enter Contact Person ", "Ok"); return;
            }

            //
            if (String.IsNullOrEmpty(et_contactnum.Text))
            {
                et_contactnum.Focus(); DisplayAlert("Alert", "Please Enter Contact Number ", "Ok"); return;
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
                et_country.Focus(); DisplayAlert("Alert", "Please Enter Country", "Ok"); return;
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
            if (String.IsNullOrEmpty(et_empcatgeory.Text))
            {
                et_empcatgeory.Focus(); DisplayAlert("Alert", "Please Enter Categeory ", "Ok"); return;
            }

            if (String.IsNullOrEmpty(et_empcomission.Text))
            {
                et_empcomission.Focus(); DisplayAlert("Alert", "Please Enter EmpCommision ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_emailid.Text))
            {
                et_emailid.Focus(); DisplayAlert("Alert", "Please Enter EmailId ", "Ok"); return;
            }
            BusinessLogicViewModel.InsertAddEmployee(Convert.ToInt32(et_emp_code.Text), et_emp_name.Text, et_contactnum.Text, et_address1.Text, et_address2.Text, et_country.Text, et_state.Text, et_city.Text, et_zip.Text, et_emailid.Text);

        }
    }
}
