using EretailApp.Model;
using EretailApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace EretailApp
{
    public partial class AddCustomer : ContentPage
    {
        BusinessLogicViewModel vm;
        List<CustomerMaster> lstcust;
        HttpResponseMessage response;
        public AddCustomer()
        {
            try
            {
                InitializeComponent();
                //BindingContext = vm = new BusinessLogicViewModel();
                //vm.ExecuteLoad_CustomerAzure();
                //lstcust = new List<CustomerMaster>();
                //lstcust = BusinessLogicViewModel.GetCustomer().ToList<CustomerMaster>();

                //
               // Countrypic.ItemsSource = BusinessLogicViewModel.GetHierarchy_1().ToList<Hierarchy_1>();

               // GetCountries_Api();
            }
            catch (Exception e)
            {

            }
        }

        public async void GetApi()
        {
            var content = "";
            HttpClient client = new HttpClient();
            var RestURL = "http://172.31.0.77/xamarin/api/Location?Type=1&id";
            client.BaseAddress = new Uri(RestURL);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
             response = await client.GetAsync(RestURL);
            content = await response.Content.ReadAsStringAsync();

        }
        public async void GetCountries_Api()
        {
            try
            {


               // GetApi();
                // List<Location> points = JsonConvert.DeserializeObject<List<Location>>(content);

                /*
                string result = js.Deserialize<string>(Result);
                Location result1 = JsonConvert.Deserialize<Location>(result);
                */
                var content = "";
                HttpClient client = new HttpClient();
                var RestURL = "http://172.31.0.77/xamarin/api/Location?Type=1&id";
                client.BaseAddress = new Uri(RestURL);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                response = await client.GetAsync(RestURL);
                content = await response.Content.ReadAsStringAsync();


                string result = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                //var id = result.id;
                // string lastresult = JsonConvert.DeserializeObject<string>(result);
                //List<Location> loc = new List<Location>();
                //Location1 l = new Location1();
                   var result1 = JsonConvert.DeserializeObject<List<Location>>(result).ToList<Location>();
                //dynamic list = JsonConvert.DeserializeObject(text);

                //dynamic result1 = JsonConvert.DeserializeObject<Location>(result);

                //foreach (var Code in result1.getResult)
                //{
                //    string name = Code.name;
                //    statepic.Items.Add(name); // Here I want to assign code for each names like "DataValue" and "DataText" ...
                //}


                // var Items = JsonConvert.DeserializeObject<List<Location>>(content);
              //  statepic.ItemsSource = result1;



            }
            catch (Exception e)
            {

            }
        }


        private void cancel_clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());

        }



        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }


        private void Button_Save_Customer_Clicked(object sender, EventArgs e)
        {
            //Int64 custCode, string Custname, string contactno, string address1, string address2, string country, string state, string city, string zip, string email)

            if (String.IsNullOrEmpty(et_customer_code.Text))
            {
                et_customer_code.Focus();
                DisplayAlert("Alert", "Please Enter Customer Code ", "Ok");
                return;
            }
            if (String.IsNullOrEmpty(et_customer_name.Text))
            {
                et_customer_name.Focus();
                DisplayAlert("Alert", "Please Enter Customer Name ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_contact_number.Text))
            {
                et_contact_number.Focus();
                DisplayAlert("Alert", "Please Enter Contact Number ", "Ok"); return;
            }

            //
            if (String.IsNullOrEmpty(et_address1.Text))
            {
                et_address1.Focus(); DisplayAlert("Alert", "Please Enter Address1 ", "Ok"); return;
            }
            //address2, string country, string state, string city, string zip, string email)
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
            if (String.IsNullOrEmpty(et_zip.Text))
            {
                et_zip.Focus(); DisplayAlert("Alert", "Please Enter Zip ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_emailid.Text))
            {
                et_emailid.Focus(); DisplayAlert("Alert", "Please Enter Email ", "Ok"); return;
            }
            if (String.IsNullOrEmpty(et_creditlimit.Text))
            {
                et_creditlimit.Focus(); DisplayAlert("Alert", "Please Enter Credit Limit ", "Ok"); return;
            }
            
            //Int64 CustomerCodeExists = BusinessLogicViewModel.GetCode("Select Cust_Code from CustomerMaster  Where Cust_Name='" + et_customer_name.Text + "'");
            //if (CustomerCodeExists == 0)
            //{
            //    Int64 CustCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(Cust_Code),0) as Cust_Code from CustomerMaster");
            //    CustCode++;
                BusinessLogicViewModel.InsertAddCustomer(Convert.ToInt32(et_customer_code.Text), et_customer_name.Text, et_contact_number.Text, et_address1.Text, et_address2.Text, et_country.Text, et_state.Text, et_city.Text, et_zip.Text, et_emailid.Text);
            //  }
           // BusinessLogicViewModel.PushLocalData();
        }

        //private void Countrypicker_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var name = Countrypic.Items[Countrypic.SelectedIndex];

        //}
    }

    //public class Location1
    //{
    //    public List<Location> name=new List<Location>();
    //}
    //public class Location
    //{
        
    //    public string name { get; set; }
    //}


}