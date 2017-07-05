using EretailApp.Menuitem;
using EretailApp.ViewModel;
using EretailApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace EretailApp
{
    public partial class MainPage : MasterDetailPage
    {

        public List<MasterPageItem> menuList
        {

            get; set;

        }

        public List<MasterPageItem> menuList1
        {

            get; set;

        }
      

        public object DisplayTitle { get; private set; }

        public MainPage()
        {

            InitializeComponent();

            menuList = new List<MasterPageItem>();
            
            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Home", Icon = "home.png", TargetType = typeof(Home) };
            var page2 = new MasterPageItem() { Title = "Sales", Icon = "sal.png", TargetType = typeof(Sales) };
            var page3 = new MasterPageItem() { Title = "Masters", Icon = "prod.png", TargetType = typeof(Products) };
           
            var page4 = new MasterPageItem() { Title = "Reports", Icon = "sss.png", TargetType = typeof(Reports) };
            var page5 = new MasterPageItem() { Icon = "recive.png", Title = "Receiving / Returns" };
            var page6 = new MasterPageItem() { Icon = "recive.png", Title = "Stock" };
            var page7 = new MasterPageItem() { Title = "Settings", Icon = "setting.png", TargetType = typeof(Setup) };
            var page8 = new MasterPageItem() { Title = "Logout", Icon = "logout.png", TargetType = typeof(Logout) };
          //  var page8 = new MasterPageItem() { Title = "Categeory", Icon = "categeory.png",  TargetType = typeof(categoryForm) };

            //var page6 = new MasterPageItem() { Title = "Login", Icon = "bui.png", TargetType = typeof(Page3) };
            //var page7 = new MasterPageItem() { Title = "Register", Icon = "sim.png", TargetType = typeof(Page1) };
            //var page8 = new MasterPageItem() { Title = "MainScreen", Icon = "fire.png", TargetType = typeof(Page2) };
            //var page9 = new MasterPageItem() { Title = "MastersPage", Icon = "msg.png", TargetType = typeof(Page3) };

            // Adding menu items to menuList
            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            menuList.Add(page7);
            menuList.Add(page8);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;
           
            // Initial navigation, this can be used for our home page



           Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));

        }



        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        }

        // Event for Menu Item selection, here we are going to handle navigation based
        // on user selection in menu ListView
        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MasterPageItem)e.SelectedItem;
            Type page = item.TargetType;

            if (item.Title.Equals("Masters"))
            {
                item = (MasterPageItem)e.SelectedItem;
                navigationDrawerList.IsVisible = false;
                menuList1 = new List<MasterPageItem>();

                // Creating our pages for menu navigation
                // Here you can define title for item, 
                // icon on the left side, and page that you want to open after selection


                var page1 = new MasterPageItem() { Icon1 = "prod.png", Title = "Product", TargetType = typeof(ProductDetails) };
                var page2 = new MasterPageItem() { Icon1 = "prod.png", Title = "Menu Master", TargetType = typeof(ProductDetails) };
                var page3 = new MasterPageItem() { Icon1 = "prod.png", Title = "Kitchen Master", TargetType = typeof(ProductDetails) };
                var page4 = new MasterPageItem() { Icon1 = "prod.png", Title = "Combi Master", TargetType = typeof(ProductDetails) };
                var page5 = new MasterPageItem() { Icon1 = "categeory.png", Title = "Category", TargetType = typeof(categoryForm) };
                var page6 = new MasterPageItem() { Icon1 = "departmnt.png", Title = "Department" };
                var page7 = new MasterPageItem() { Icon1 = "brand.png", Title = "Brand" };
                var page8 = new MasterPageItem() { Icon1 = "supply.png", Title = "Vendor" };
                var page9 = new MasterPageItem() { Icon1 = "tax.png", Title = "Tax" };
                var page10 = new MasterPageItem() { Title = "Customer", Icon1 = "customer.png", TargetType = typeof(Customer) };
              var page11 = new MasterPageItem() { Icon1 = "customer.png", Title = "Employee" };
                //var page6 = new MasterPageItem() { Title = "Login", Icon = "bui.png", TargetType = typeof(Page3) };
                //var page7 = new MasterPageItem() { Title = "Register", Icon = "sim.png", TargetType = typeof(Page1) };
                //var page8 = new MasterPageItem() { Title = "MainScreen", Icon = "fire.png", TargetType = typeof(Page2) };
                //var page9 = new MasterPageItem() { Title = "MastersPage", Icon = "msg.png", TargetType = typeof(Page3) };

                // Adding menu items to menuList
                menuList1.Add(page1);
                menuList1.Add(page2);
                menuList1.Add(page3);
                menuList1.Add(page4);
                menuList1.Add(page5);
                menuList1.Add(page6);
                //menuList1.Add(page7);
                menuList1.Add(page8);

                if (BusinessLogicViewModel.EnableBrand == "1")
                {
                    menuList1.Add(page7);
                }
                if (BusinessLogicViewModel.EnableTax == "1")
                {
                    menuList1.Add(page9);
                }

                //menuList1.Add(page9);
                menuList1.Add(page10);
                menuList1.Add(page11);
                navigationDrawerList1.IsVisible = true;
                // Setting our list to be ItemSource for ListView in MainPage.xaml
                navigationDrawerList1.ItemsSource = menuList1;

                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));
            }
            //else if (item.Title.Equals("Setup"))
            //{
            //    item = (MasterPageItem)e.SelectedItem;
            //    navigationDrawerList.IsVisible = false;
            //    menuList1 = new List<MasterPageItem>();

            //    // Creating our pages for menu navigation
            //    // Here you can define title for item, 
            //    // icon on the left side, and page that you want to open after selection
            //    var page1 = new MasterPageItem() { Icon1 = "prod.png", Title = "Language" };
            //    // var page2 = new MasterPageItem() { Icon1 = "brand.png", Title = "Business" };
            //    var page2 = new MasterPageItem() { Icon1 = "categeory.png", Title = "Payment Mode" };
            //    var page3 = new MasterPageItem() { Icon1 = "departmnt.png", Title = "Billing Mode" };
            //    var page4 = new MasterPageItem() { Icon1 = "brand.png", Title = "Bill Printing" };
            //    var page5 = new MasterPageItem() { Icon1 = "supply.png", Title = "Hardware Setting" };
            //    var page6 = new MasterPageItem() { Icon1 = "tax.png", Title = "SMS/Notification" };

            //    //var page6 = new MasterPageItem() { Title = "Login", Icon = "bui.png", TargetType = typeof(Page3) };
            //    //var page7 = new MasterPageItem() { Title = "Register", Icon = "sim.png", TargetType = typeof(Page1) };
            //    //var page8 = new MasterPageItem() { Title = "MainScreen", Icon = "fire.png", TargetType = typeof(Page2) };
            //    //var page9 = new MasterPageItem() { Title = "MastersPage", Icon = "msg.png", TargetType = typeof(Page3) };

            //    // Adding menu items to menuList
            //    menuList1.Add(page1);
            //    menuList1.Add(page2);
            //    menuList1.Add(page3);
            //    menuList1.Add(page4);
            //    menuList1.Add(page5);
            //    menuList1.Add(page6);
            //    // menuList1.Add(page7);
            //    //menuList.Add(page9);
            //    navigationDrawerList1.IsVisible = true;
            //    // Setting our list to be ItemSource for ListView in MainPage.xaml
            //    navigationDrawerList1.ItemsSource = menuList1;

            //    Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));

            //}


        
            else if (item.Title.Equals("Settings")) {
                Navigation.PushModalAsync(new Setup());


            }

            else if (item.Title.Equals("Receiving / Returns"))
            {
                Navigation.PushModalAsync(new TransactionsForm());

                // Detail = new TransactionsForm();
                //headertitle.Text = item.Title;


            }


            else if (item.Title.Equals("Stock"))
            {

               Navigation.PushModalAsync(new StockForm());

                // Detail = new StackingForm();
                //headertitle.Text = item.Title;


            }


            else if (item.Title.Equals("Logout"))
            {
                Navigation.PushModalAsync(new LoginForm());

            }


            else
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(page));
                IsPresented = false;
            }



        }


        private  void OnMenuItemSelectedproducts(object sender, SelectedItemChangedEventArgs ee)
        {

            var item = (MasterPageItem)ee.SelectedItem;
            Type page = item.TargetType;

            // Masters options

            if (item.Title.Equals("Employee"))
            {
                //Navigation.PushModalAsync(new ProductDetails());
                Detail = new EmployeeForm();
                //headertitle.Text = item.Title;
               


            }

            if (item.Title.Equals("Product"))
            {
                //Navigation.PushModalAsync(new ProductDetails());
                Detail = new ProductDetails();
              //  headertitle.Text = item.Title;
              

            }

        if (item.Title.Equals("Category"))
            {
               // Navigation.PushModalAsync(new categoryForm());

               Detail = new categoryForm();
               // headertitle.Text = item.Title;

            }


            if (item.Title.Equals("Department"))
            {
                // Navigation.PushModalAsync(new categoryForm());

                Detail = new DeptForm();
              //  headertitle.Text = item.Title;

            }

            if (item.Title.Equals("Brand"))
            {
                // Navigation.PushModalAsync(new categoryForm());

                Detail = new BrandForm();
               // headertitle.Text = item.Title;

            }


            if (item.Title.Equals("Tax"))
            {
                // Navigation.PushModalAsync(new categoryForm());

                Detail = new TaxForm();
               // headertitle.Text = item.Title;

            }



            if (item.Title.Equals("Vendor"))
            {
                // Navigation.PushModalAsync(new categoryForm());

                Detail = new SupplierFormxaml();
               // headertitle.Text = item.Title;


            }

         if (item.Title.Equals("Customer"))
            {
                Detail = new CustomerForm();

            }




            if (item.Title.Equals("Menu Master"))
            {
                Detail = new MenuMaster();

            }

            if (item.Title.Equals("Kitchen Master"))
            {
                Detail = new KitchenMaster();

            }
            if (item.Title.Equals("Combi Master"))
            {
                Detail = new CombiMaster();

            }





            // settings  options 


            //if (item.Title.Equals("Language"))
            //{

            //    Detail = new Language();
            //    headertitle.Text = item.Title;


            //}
            //if (item.Title.Equals("Billing Mode"))
            //{

            //    Detail = new BillingMode();
            //    headertitle.Text = item.Title;


            //}
            //if (item.Title.Equals("SMS/Notification"))
            //{

            //    var action = await DisplayActionSheet("Choose Any One ", "Cancel", null, "Business", "Customer");
            //    switch (action)
            //    {
            //        case "Business":
            //            // Device.OpenUri(new Uri("https://www.google.com/gmail/about/"));
            //            Detail = new Business();
            //            headertitle.Text = item.Title;
            //            break;
            //        case "Customer":
            //            // Device.OpenUri(new Uri("https://twitter.com/login"));
            //            Detail = new CustomerForm();
            //            headertitle.Text = item.Title;
            //            break;

            //    }


            //}


            //if (item.Title.Equals("Payment Mode"))
            //{

            //    Detail = new PaymentMode();
            //    headertitle.Text = item.Title;


            //}

            //if (item.Title.Equals("Bill Printing"))
            //{

            //    Detail = new BillPrinting();
            //    headertitle.Text = item.Title;


            //}

            //if (item.Title.Equals("Hardware Setting"))
            //{

            //    Detail = new HardwareSetting();
            //    headertitle.Text = item.Title;


            //}

            //if (item.Title.Equals("Business"))
            //{

            //    Detail = new Business();
            //    headertitle.Text = item.Title;


            //}






        }

        public void back(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }



       







    }
}