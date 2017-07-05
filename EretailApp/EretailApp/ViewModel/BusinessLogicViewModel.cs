using EretailApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmHelpers;
using Plugin.Connectivity;
using SQLite.Net;
using Sqlloginbusinesslogic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace EretailApp.ViewModel
{
    public class BusinessLogicViewModel : BaseViewModel
    {
        static AzureService azureService; public MobileServiceClient Client = null;
        public static IMobileServiceTable<SkuMaster> skuMaster;
      //  public static IMobileServiceSyncTable<SkuMaster> skuMaster1;
        public static SQLiteConnection _sqlconnection;
        public static IMobileServiceTable<PluMasterPrices> pluMasterprices;
        public BusinessLogicViewModel()
        {
            if (Client?.SyncContext?.IsInitialized ?? false)
                return;
            //var appUrl = "http://172.31.0.77/XamarinAzure";
            var appUrl = "http://xamarinprojazureapi.azurewebsites.net";
            Client = new MobileServiceClient(appUrl);
            azureService = DependencyService.Get<AzureService>();
            skuMaster = Client.GetTable<SkuMaster>();
           // skuMaster1 = Client.GetSyncTable<SkuMaster>();
            pluMasterprices = Client.GetTable<PluMasterPrices>();
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
        }
        public static String ListItemValue = "";
        public static String CameraSkuCode = "";
        public static bool CamOpen;
        public static String EnableTax = "0";
        public static String EnableBrand = "0";
        public static String EnableH1 = "0";
        public static String EnableH2 = "0";
        public static String EnableH3 = "0";
        public static String EnableH4 = "0";
        public static String EnableH5 = "0";
        public static String EnableHierarchyGroup = "0";
        public static String EnableUOM = "0";
        public static String EnableMarkUp = "0";
        public static String SkuIdvalue = "";
        public static String PluIdvalue = "";

        public static String H1_Group = "";
        public static String user = "";
        public static String password = "";
        public static String EnableAutoSkucode = "0";
        public static int LastSkucode = 0;
        public static bool CheckConnection = !CrossConnectivity.Current.IsConnected;
        public static string ConvertThreeDecimal(Entry e)
        {
            String ThreeDecimal = Convert.ToDecimal(e.Text).ToString("#,###0.000");
            return ThreeDecimal;
        }
        public static string ConvertTwoDecimal(BoxBorderEntry e)
        {
            String TwoDecimal = Convert.ToDecimal(e.Text).ToString("#,##0.00");
            return TwoDecimal;
        }
        public static void DisplayErrorMessage(string s1, string s2, Page p)
        {
            MessagingCenter.Send(p, s1, s2);
        }

        public static string ExecuteNonQuery(string ColumnCode, string TableName, string ColumnDesc, object obj)
        {
            String sql = "Select " + ColumnCode + " from " + TableName + " Where='" + ColumnDesc + "'";
            _sqlconnection.ExecuteScalar<object>(sql);
            return "";
        }
        public static IEnumerable<HierarchyGroup> GetHierarchy_Group()
        {
            return (from t in _sqlconnection.Table<HierarchyGroup>() select t).ToList();
        }

        public static IEnumerable<HierarchyGroupDescription> GetHG(string query)
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            SQLiteCommand sqlcom = _sqlconnection.CreateCommand(query);

            return (sqlcom.ExecuteQuery<HierarchyGroupDescription>()).ToList();
        }
        //

        public static IEnumerable<SkuMaster> GetSkumasterDataupdate(string query)
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            SQLiteCommand sqlcom = _sqlconnection.CreateCommand(query);

            return (sqlcom.ExecuteQuery<SkuMaster>().ToList());
        }


        public static IEnumerable<PluMasterPrices> GetPlumasterDataupdate(string query)
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            SQLiteCommand sqlcom = _sqlconnection.CreateCommand(query);

            return (sqlcom.ExecuteQuery<PluMasterPrices>().ToList());
        }


        ////Get specific student
        //public Student GetStudent(int id)
        //{
        //    return _sqlconnection.Table<Student>().FirstOrDefault(t => t.Id == id);
        //}
        public static IEnumerable<SkuMaster> GetSingleSku(string skucode,string query)
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            //SQLiteCommand sqlcom = _sqlconnection.CreateCommand(query);
         yield return _sqlconnection.Table<SkuMaster>().FirstOrDefault(t => t.SkuCode == skucode);

            //  return(sqlcom.ExecuteQuery<SkuMaster>().ToList());
        }

        //get single plumaster

        public static IEnumerable<PluMasterPrices> GetSinglePlu(string skucode, string query)
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            //SQLiteCommand sqlcom = _sqlconnection.CreateCommand(query);
            yield return _sqlconnection.Table<PluMasterPrices>().FirstOrDefault(t => t.SkuCode == skucode);

            //  return(sqlcom.ExecuteQuery<SkuMaster>().ToList());
        }


        //
        public static IEnumerable<Hierarchy_1> GetHierarchy_1()
        {
            return (from t in _sqlconnection.Table<Hierarchy_1>() select t).ToList();
        }
      //  public static IEnumerable<SkuMaster> GetSingleSku11(string skucode, string query)
      //  {
      //      IEnumerable<SkuMaster> SkuMaster =
      //from SkuMaster in database.Stores
      //where SkuMaster.CompanyID == curCompany.ID
      //select new SkuMaster { Value = SkuMaster., Text = SkuMaster.ID };

      //      ViewBag.storeSelector = stores;

      //  }
        public static IEnumerable<SkuMaster> GetSkumaster1(string skuc)
        {
            //SkuMaster ss = new SkuMaster();
            return (from t in _sqlconnection.Table<SkuMaster>() where t.SkuCode == skuc select t).ToList();
        }
        //t => t.SkuCode == skucode
        public static IEnumerable<SkuMaster> GetSkumaster()
        {
            return (from t in _sqlconnection.Table<SkuMaster>() select t).ToList();
        }
        public static IEnumerable<PluMasterPrices> GetPlumaster()
        {
            return (from t in _sqlconnection.Table<PluMasterPrices>() select t).ToList();
        }
        public static IEnumerable<Hierarchy_2> GetHierarchy_2()
        {
            return (from t in _sqlconnection.Table<Hierarchy_2>() select t).ToList();
        }
        public static IEnumerable<Brand> GetBrand()
        {
            return (from t in _sqlconnection.Table<Brand>() select t).ToList();
        }

        public static IEnumerable<VendorMaster> GetVendor()
        {
            return (from t in _sqlconnection.Table<VendorMaster>() select t).ToList();
        }

        public static IEnumerable<UOMeasurement> GetUom()
        {
            return (from t in _sqlconnection.Table<UOMeasurement>() select t).ToList();
        }

        public static IEnumerable<TaxFile> GetTax()
        {
            return (from t in _sqlconnection.Table<TaxFile>() select t).ToList();
        }
        public static IEnumerable<CustomerMaster> GetCustomer()
        {
            return (from t in _sqlconnection.Table<CustomerMaster>() select t).ToList();
        }
        public static IEnumerable<EmployeeMaster> GetEmployee()
        {
            return (from t in _sqlconnection.Table<EmployeeMaster>() select t).ToList();
        }
        public static IEnumerable<VendorAddresse> GetVendorAddress()
        {
            return (from t in _sqlconnection.Table<VendorAddresse>() select t).ToList();
        }

        public ObservableRangeCollection<SkuMaster> SkuList { get; } = new ObservableRangeCollection<SkuMaster>();
        public ObservableRangeCollection<HierarchyGroup> HierarchyGroupList { get; } = new ObservableRangeCollection<HierarchyGroup>();
        public ObservableRangeCollection<Hierarchy_1> Hierarchy_1List { get; } = new ObservableRangeCollection<Hierarchy_1>();
        public ObservableRangeCollection<Hierarchy_2> Hierarchy_2List { get; } = new ObservableRangeCollection<Hierarchy_2>();
        public ObservableRangeCollection<Brand> BrandList { get; } = new ObservableRangeCollection<Brand>();
        public ObservableRangeCollection<VendorMaster> VendorList { get; } = new ObservableRangeCollection<VendorMaster>();
        public ObservableRangeCollection<UOMeasurement> UomList { get; } = new ObservableRangeCollection<UOMeasurement>();
        public ObservableRangeCollection<TaxFile> TaxList { get; } = new ObservableRangeCollection<TaxFile>();
        public ObservableRangeCollection<PluMasterPrices> PluList { get; } = new ObservableRangeCollection<PluMasterPrices>();
        public ObservableRangeCollection<CustomerMaster> CustomerList { get; } = new ObservableRangeCollection<CustomerMaster>();
        public ObservableRangeCollection<EmployeeMaster> EmployeeList { get; } = new ObservableRangeCollection<EmployeeMaster>();
        public ObservableRangeCollection<VendorAddresse> VendorAddressList { get; } = new ObservableRangeCollection<VendorAddresse>();
        //public ObservableRangeCollection<SkuMaster> SkuList { get; } = new ObservableRangeCollection<SkuMaster>();
      //  public ObservableRangeCollection<Grouping<string, SkuMaster>> SkuGrouped { get; set; } = new ObservableRangeCollection<Grouping<string, SkuMaster>>();
        //ICommand loadSkuMasterCommand;
        //public ICommand LoadSkuMasterCommand =>
        //    loadSkuMasterCommand ?? (loadSkuMasterCommand = new Command(async () => await ExecuteLoadSkuMasterCommandAsync()));
        string loadingMessage;

        public string LoadingMessage
        {
            get { return loadingMessage; }
            set { SetProperty(ref loadingMessage, value); }
        }
        public static void SaveTaskAsync(SkuMaster item, PluMasterPrices pluitem)
        {
            try { 
            skuMaster.InsertAsync(item);
            pluMasterprices.InsertAsync(pluitem);
                
        }
            catch (Exception e)
            {
            }
}

        public static async void UpdateTaskAsync(SkuMaster item, PluMasterPrices pluitem)
        {
            try
            {
              await skuMaster.UpdateAsync(item);
              await  pluMasterprices.UpdateAsync(pluitem);

            }
            catch (Exception e)
            {
            }
        }


        public static int ExecuteNonQuery(SQLiteConnection connection, string commandType, string commandText)
        {
            // Pass through the call providing null for the set of SqlParameters
            return ExecuteNonQuery(connection, commandType, commandText);
        }
        public static Int64 GetCode(string query)
        {
            _sqlconnection = DependencyService.Get<ISQLite>().GetConnection();
            SQLiteCommand sqlcom = _sqlconnection.CreateCommand(query);
            return (sqlcom.ExecuteScalar<Int64>());

        }
        public async Task ExecuteLoadH2_CategeoryAzure()
        {
            try
            {
                var hierarchy2list = await azureService.GetMain_AzureHierarchy_2Async();
                Hierarchy_2List.ReplaceRange(hierarchy2list);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Hirerachy_Categeory", e.Message, "OK");
            }
        }

        public async Task ExecuteLoadH1_DepartmentAzure()
        {
            try
            {
                var hierarchy1list = await azureService.GetMain_AzureHierarchy_1Async();
                Hierarchy_1List.ReplaceRange(hierarchy1list);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Hirerachy_Department", e.Message, "OK");
            }
        }
            public async Task ExecuteLoadBrandAzure()
        {
            try
            {
                var brandlist = await azureService.GetMain_AzureBrandAsync();
                BrandList.ReplaceRange(brandlist);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Hirerachy_Brand", e.Message, "OK");
            }
        }

        public async Task ExecuteLoad_TaxAzure()
        {
            try
            {
                var taxlist = await azureService.GetMain_AzureTaxFileAsync();
                TaxList.ReplaceRange(taxlist);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Hirerachy_Tax", e.Message, "OK");
            }
        }

        public async Task ExecuteLoad_CustomerAzure()
        {
            try
            {
                var custlist = await azureService.GetMain_CustomerAzureAsync();
                CustomerList.ReplaceRange(custlist);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error Customer", e.Message, "OK");
            }
        }

        public async Task ExecuteLoad_EmployeeAzure()
        {
            try
            {
                var emplist = await azureService.GetMain_EmployeeAzureAsync();
                EmployeeList.ReplaceRange(emplist);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error Employee", e.Message, "OK");
            }
        }
        public async Task ExecuteLoad_VendorAddressAzure()
        {
            try
            {
                var vendoraddlist = await azureService.GetMain_VendorAddressAzureAsync();
                VendorAddressList.ReplaceRange(vendoraddlist);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error Employee", e.Message, "OK");
            }
        }


        public async Task ExecuteLoadCommandAsync()
        {
            //
            
                IsBusy = true;
                try
                {
                    var hierarchyGrouplist = await azureService.GetMain_AzureHierarchyGroupAsync();
                    HierarchyGroupList.ReplaceRange(hierarchyGrouplist);
                }catch(Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Sync Error1", e.Message, "OK");
                }
                try { 
                var hierarchy1list = await azureService.GetMain_AzureHierarchy_1Async();
                Hierarchy_1List.ReplaceRange(hierarchy1list);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error3", e.Message, "OK");
                }
            try { 
            var hierarchy2list = await azureService.GetMain_AzureHierarchy_2Async();
                Hierarchy_2List.ReplaceRange(hierarchy2list);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error4", e.Message, "OK");
            }


            try
            {
                var Skumasterlist = await azureService.GetMain_SkuMasterAzureAsync();
                SkuList.ReplaceRange(Skumasterlist);
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error4", e.Message, "OK");
            }



            try
            {
                    var brandlist = await azureService.GetMain_AzureBrandAsync();
                    BrandList.ReplaceRange(brandlist);
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Sync Error5", e.Message, "OK");
                }
                try { 
                var vendorlist = await azureService.GetMain_VendorAzureAsync();
                VendorList.ReplaceRange(vendorlist);
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Sync Error6", e.Message, "OK");
                }
                try { 
                var Uomlist = await azureService.GetMain_UOMAzureAsync();
                UomList.ReplaceRange(Uomlist);
                }
                catch (Exception e)
                {
                    await Application.Current.MainPage.DisplayAlert("Sync Error7", e.Message, "OK");
                }
            
                try
            {
                var plulist = await azureService.GetMain_PluMasterPrices();
                PluList.ReplaceRange(plulist);
            }catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error plumaster", e.Message, "OK");
            }
                try { 
                var taxlist = await azureService.GetMain_AzureTaxFileAsync();
                TaxList.ReplaceRange(taxlist);
                //SortSkuMaster();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Sync Error8", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public static async Task InsertAddH1(Int64 Code, string Desc)
        {
            try
            {
                azureService.AddH1(Code, Desc);

            }
            catch (Exception e)
            {
            }
    
            }

       
        public static async Task InsertAddHG(Int64 HGCode, Int64 H1Code, Int64 H2Code)
        {
            try
            {
                azureService.AddHG(HGCode, H1Code, H2Code);
            }
            catch (Exception e)
            {
            }
            

    }
    public static async Task InsertAddH2(Int64 Code, string Desc)
        {
            try
            {
                azureService.AddH2(Code, Desc);
            }
            catch (Exception e)
            {
            }

    }
       

        public static async Task InsertAddBrand(Int64 Code, string Desc)
        {
            try { 
            azureService.AddBrand(Code, Desc);
            }
            catch (Exception e)
            {
            }
        }
        public static async Task InsertAddUOM(Int64 Code, string Desc)
        {
            try
            {
                azureService.AddUOM(Code, Desc);
            }
            catch (Exception e)
            {
            }
            }
        public static async Task InsertAddVendor(Int64 Code, string Desc)
        {
            try { 
            azureService.AddVendor(Code, Desc);
        }
            catch (Exception e)
            {
            }
}
        public static async Task InsertAddCustomer(Int64 custCode, string Custname, string contactno, string address1, string address2, string country, string state, string city, string zip, string email)
        {
            try
            {
                azureService.AddCustomer(custCode,Custname,contactno,address1,address2,country,state,city,zip,email);
            }
            catch (Exception e)
            {
            }

        }
        public static async Task InsertAddEmployee(Int64 EmpCode, string empname, string contactno, string address1, string address2, string country, string state, string city, string zip, string email)
        {
            try
            {
                azureService.AddEmployee(EmpCode, empname, contactno, address1, address2, country, state, city, zip, email);
            }
            catch (Exception e)
            {
            }
        }
        public static async Task InsertAddVendorAddress(Int64 VendorCode, string contactno, string address1, string address2, string state, string country, string email, string zip)
        {
            try
            {
                azureService.AddVendorAddress(VendorCode, contactno, address1, address2, state, country, email, zip);
            }
            catch (Exception e)
            {
            }

        }

        public static async Task InsertAddTax(Int64 Code, string Desc)
        {
            try { 
            azureService.AddTax(Code, Desc);
        }
            catch (Exception e)
            {
            }
}
        public static async Task PushLocalData()
        {
            try { 
            azureService.PushAsync();
        }
            catch (Exception e)
            {
            }
}
        //public static void ListViewSearch(object model, ListView lv, string s1, string s2, string s3)
        //{
        //    try
        //    {
        //        IEnumerable enumerable = (IEnumerable)model.GetType().Name;
        //        enumerable = ll.Where(name1 => name1.name.Contains(s1) || name1.name.Contains(s2) || name1.name.Contains(s3));
        //        lv.ItemsSource = enumerable;
        //    }
        //    catch (Exception ee)
        //    {

        //    }
        //}
        ////void SortSkuMaster()
        ////{
        ////    var groups = from sku in Coffees
        ////                 orderby sku. descending
        ////                 group coffee by coffee.Productcode
        ////        into skuGroup
        ////                 select new Grouping<string, SkuMaster>($"{skuGroup.Key} ({skuGroup.Count()})", skuGroup);


        ////    SkuGrouped.ReplaceRange(groups);
        ////}
        //public void SortSkuMaster()
        //{
        //    //var groups = from coffee in SkuList
        //    //             orderby coffee.SkuCode descending
        //    //             group coffee by coffee.SkuCode
        //    //    into SkuGrouped
        //    //             select new Grouping<string, SkuMaster>($"{SkuGrouped.Key} ({SkuGrouped.Count()})", SkuGrouped);
        //    //SkuGrouped.ReplaceRange(groups);
        //}
        //public Task<bool> LoginAsync()
        //{
        //    if (Settings.IsLoggedIn)
        //        return Task.FromResult(true);


        //    return azureService.LoginAsync();
        //}
    }
}

