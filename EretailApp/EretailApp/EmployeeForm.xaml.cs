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
    public partial class EmployeeForm : ContentPage
    {
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
        List<EmployeeMaster> lstemp;
        public EmployeeForm()
        {
            InitializeComponent();
            //EmpList.ItemsSource = ll;
            BindingContext = vm = new BusinessLogicViewModel();
            vm.ExecuteLoad_EmployeeAzure();
            lstemp = new List<EmployeeMaster>();
            lstemp = BusinessLogicViewModel.GetEmployee().ToList<EmployeeMaster>();

            EmpList.ItemsSource = lstemp;

        }
        //public void btnclick(Object o, EventArgs e)
        //{

        //    //String str = searchvalue.Text;
        //    //IEnumerable<ProductModel> searchresult = ll.Where(name1 => name1.name.Contains(str));
        //    //EmpList.ItemsSource = searchresult;

        //    //if (str.Equals(""))
        //    //{
        //    //    ll.Clear();
        //    //}

        //}

        public void AddEmp(Object o, EventArgs e)
        {
            Navigation.PushModalAsync(new AddEmpForm());
        }

        private void searchvalue_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {



                EmpList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    EmpList.ItemsSource = lstemp;
                else
                    EmpList.ItemsSource = lstemp.Where(i => i.Emp_Name.ToLower().Contains(e.NewTextValue.ToLower()));

                EmpList.EndRefresh();

                //IEnumerable<Hierarchy_2> searchresult = lstH2.Where(name1 => name1.Description.Contains(txtH2.Text));
                //H2List.ItemsSource = searchresult;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
    }
}
