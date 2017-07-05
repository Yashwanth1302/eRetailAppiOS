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
    public partial class LoginForm : ContentPage
    {
        BusinessLogicViewModel vm;
        LoginSuccessResponse result1;
        public LoginForm()
        {
            InitializeComponent();
            BindingContext = vm = new BusinessLogicViewModel();
        }
        
        public async void HomePage(Object o, EventArgs e)
        {
            try
            {
                //BusinessLogicViewModel.DisplayErrorMessage("Mesg", "mesg", this);
                BindingContext = new SettingsViewModel();
                var client = new System.Net.Http.HttpClient();
                var jsonRequest = new LoginRequest { username = txtuser.Text, password = txtpassword.Text, merchantid = "E1001" };

                var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
                HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(new Uri("http://xamarinprojazureapi.azurewebsites.net/api/login?ZUMO-API-VERSION=2.0.0"), content);
               // var response = await client.PostAsync(new Uri("http://172.31.0.77/XamarinAzure/api/login?ZUMO-API-VERSION=2.0.0"), content);

                if (response.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                    //var id = result.id;
                    // string lastresult = JsonConvert.DeserializeObject<string>(result);
                    result1 = JsonConvert.DeserializeObject<LoginSuccessResponse>(result);
                    BusinessLogicViewModel.EnableTax = result1.EnableTax.ToString();
                    BusinessLogicViewModel.EnableBrand = result1.EnableBrand.ToString();
                    BusinessLogicViewModel.EnableH1 = result1.EnableH1_Group.ToString();
                    BusinessLogicViewModel.EnableH2 = result1.EnableH2_Group.ToString();
                    BusinessLogicViewModel.EnableH3 = result1.EnableH3_Group.ToString();
                    BusinessLogicViewModel.EnableH4 = result1.EnableH4_Group.ToString();
                    BusinessLogicViewModel.EnableH5 = result1.EnableH5_Group.ToString();
                    BusinessLogicViewModel.EnableHierarchyGroup = result1.EnableHierarchyGroup.ToString();
                    BusinessLogicViewModel.EnableMarkUp = result1.EnableMarkUp.ToString();
                    BusinessLogicViewModel.EnableUOM = result1.EnableUOM.ToString();
                    BusinessLogicViewModel.EnableAutoSkucode = result1.EnableAutoSkucode.ToString();
                    BusinessLogicViewModel.LastSkucode = result1.LastSkucode;

                }
                if (result1.status == 200)
                {
                    BusinessLogicViewModel.user = txtuser.Text;
                    BusinessLogicViewModel.password = txtpassword.Text;
                    await DisplayAlert("Sucess!", "User LoggedIn SucessFully", "Ok", "Cancel");
                    if (BusinessLogicViewModel.EnableTax == "0" && BusinessLogicViewModel.EnableBrand == "0")
                    {
                        await DisplayAlert("User!", "Atleast One Option Should Enabled", "Ok", "Cancel");
                        return;
                    }
                    else
                    {
                        await Navigation.PushModalAsync(new MainPage());
                    }
                }
                else
                {
                    await Navigation.PushModalAsync(new MainPage());
                    // await DisplayAlert("Login Failed!", "Invalid User", "Ok", "Cancel");

                }
                //await Navigation.PushModalAsync(new MainPage());
            }
            catch(Exception ee)
            {

            }
        }
        public class LoginRequest
        {
            public string username { get; set; }
            public string password { get; set; }
            public string merchantid { get; set; }
        }
        public class LoginSuccessResponse
        {
            public int status { get; set; }
            public string message { get; set; }
            public int EnableStore { get; set; }
            public int EnableCurrency { get; set; }
            public int EnablePaymentMode { get; set; }
            public int EnableHierarchyGroup { get; set; }
            public int EnableH1_Group { get; set; }
            public string H1_Name { get; set; }
            public int EnableH2_Group { get; set; }
            public string H2_Name { get; set; }
            public int EnableH3_Group { get; set; }
            public string H3_Name { get; set; }
            public int EnableH4_Group { get; set; }
            public string H4_Name { get; set; }
            public int EnableH5_Group { get; set; }
            public string H5_Name { get; set; }
            public int EnableBrand { get; set; }
            public int EnableMarkUp { get; set; }
            public int EnableManufacturer { get; set; }
            public int EnableUOM { get; set; }
            public int EnableTax { get; set; }
            public int EnableAutoSkucode { get; set; }
            public int LastSkucode { get; set; }
        }
    }
}


 
