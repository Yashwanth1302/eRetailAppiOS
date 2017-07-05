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
    public partial class DeptForm : ContentPage
    {

        List<Hierarchy_1> lstH1;


        //        List<ProductModel> ll = new List<ProductModel>
        //        {
        //              new ProductModel
        //           {
        //        name="Shirt",
        //        Dept="PepiJeans",
        //                category="Mens",
        //                Icon="ic_user.png",
        //         },
        //           new ProductModel
        //           {
        //                name="Jeans",
        //                Dept="PepiJeans",
        //                category="Mens",
        //                Icon="ic_user.png",

        //           }
        //           ,

        //             new ProductModel
        //           {
        //               name="T-Shirt",
        //                Dept="Pan America",
        //                category="Womens",
        //                Icon="ic_user.png",

        //           }
        //             ,
        //                 new ProductModel
        //           {
        //               name=" Round Neck T-Shirt",
        //                Dept="Us Polo",
        //                category="Kids",
        //                Icon="ic_user.png",

        //           }
        //                 ,

        //                       new ProductModel
        //           {
        //               name="Gap-TShirt ",
        //                Dept="Lives",
        //                category="Branded Shirts",
        //                Icon="ic_user.png",

        //           }

        //,

        //        };
        BusinessLogicViewModel vm;

        public DeptForm()
        {
            InitializeComponent();
            //            DepartmentList.ItemsSource = ll;
            BindingContext = vm = new BusinessLogicViewModel();
            vm.ExecuteLoadH1_DepartmentAzure();

            lstH1 = new List<Hierarchy_1>();
            lstH1 = BusinessLogicViewModel.GetHierarchy_1().ToList<Hierarchy_1>();
            DepartmentList.ItemsSource = lstH1;

        }

        public void SearchDepartmentclick(Object o, TextChangedEventArgs e)
        {

            //String str = searchDepartment.Text;
            //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
            //DepartmentList.ItemsSource = searchresult;

            try
            {

                DepartmentList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    DepartmentList.ItemsSource = lstH1;
                else
                    DepartmentList.ItemsSource = lstH1.Where(i => i.Description.ToLower().Contains(e.NewTextValue.ToLower()));

                DepartmentList.EndRefresh();
                //IEnumerable<Hierarchy_1> searchresult = lstH1.Where(name1 => name1.Description.Contains(txtH1.Text));
                //H1List.ItemsSource = searchresult;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }



        public void AddDepartment(Object o, EventArgs e)
        {
            // Navigation.PushModalAsync(new AddCategoryForm());
            DeptTitle.Text = "Department";
            CreateCategory.IsVisible = true;
        }

        private void department_save_clicked(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(entry_department_entry.Text))
                {
                    DisplayAlert("Error", "Enter Department", "Ok");
                    return;
                }
                else
                {
                    Int64 H1Exists = BusinessLogicViewModel.GetCode("Select H1_Code from Hierarchy_1 Where Description='" + entry_department_entry.Text + "'");
                    Int64 H1Code = 0;
                    if (H1Exists == 0)
                    {
                        H1Code = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(H1_Code as int)),0) as H1_Code from Hierarchy_1");
                        H1Code++;
                        BusinessLogicViewModel.InsertAddH1(H1Code, entry_department_entry.Text);
                    }
                    entry_department_entry.Text = "";

                    CreateCategory.IsVisible = false;
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
        private void department_pop_cancel_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(entry_department_entry.Text))
                {
                    DisplayAlert("Alert", "Do You Want Clear the Text" + entry_department_entry, "Yes", "No");
                    return;
                }

            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
    }
}