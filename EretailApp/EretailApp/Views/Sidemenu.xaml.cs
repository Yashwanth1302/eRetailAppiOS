using EretailApp.Menuitem;
using EretailApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EretailApp.Views
{
    public partial class Sidemenu : MasterDetailPage
    {

        public List<MasterPageItem> menuList
        {

            get; set;

        }

        public Sidemenu()
        {
            BindingContext = new SettingsViewModel();
            InitializeComponent();
          
            menuList = new List<MasterPageItem>();

            // Creating our pages for menu navigation
            // Here you can define title for item, 
            // icon on the left side, and page that you want to open after selection
            var page1 = new MasterPageItem() { Title = "Product", Icon = "arrow.png", TargetType = typeof(ProductList) };
            var page2 = new MasterPageItem() { Title = "Categeory", Icon = "arrow.png", TargetType = typeof(Sales) };
            var page3 = new MasterPageItem() { Title = "Department", Icon = "arrow.png", TargetType = typeof(Products) };
            var page4 = new MasterPageItem() { Title = "Brand", Icon = "arrow.png", TargetType = typeof(Customer) };
            var page5 = new MasterPageItem() { Title = "Supplier", Icon = "arrow.png", TargetType = typeof(Reports) };
            var page6 = new MasterPageItem() { Title = "Tax", Icon = "arrow.png", TargetType = typeof(Setup) };
            var page7 = new MasterPageItem() { Title = "Receving/Returns", Icon = "arrow.png", TargetType = typeof(Logout) };


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
            //menuList.Add(page9);

            // Setting our list to be ItemSource for ListView in MainPage.xaml
            navigationDrawerList.ItemsSource = menuList;

            // Initial navigation, this can be used for our home page
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(Home)));
        }

        protected override bool OnBackButtonPressed()
        {
            // Do your magic here
            return true;
        } }
}
    