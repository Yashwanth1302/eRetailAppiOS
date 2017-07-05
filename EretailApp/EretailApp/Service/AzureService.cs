using System.Runtime.Serialization;
using System;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.Diagnostics;
using Xamarin.Forms;
using EretailApp;
using System.IO;
using Plugin.Connectivity;
using EretailApp.Model;
using EretailApp;
using EretailApp.ViewModel;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http;

[assembly: Dependency(typeof(AzureService))]
namespace EretailApp
{
    public class AzureService
    {

        // public MobileServiceClient Client { get; set; } = null;

        public MobileServiceClient Client = null;
        public static IMobileServiceTable<SkuMaster> SkuMasterTable;
        public static IMobileServiceTable<PluMasterPrices> pluMasterTable;

        public static IMobileServiceSyncTable<SkuMaster> SkuMastertab;
        public static IMobileServiceSyncTable<PluMasterPrices> plumastertab;


        public static IMobileServiceSyncTable<HierarchyGroup> HierarchyGroupTable;
        public static IMobileServiceSyncTable<Hierarchy_1> Hierarchy_1Table;
        public static IMobileServiceSyncTable<Hierarchy_2> Hierarchy_2Table;
        public static IMobileServiceSyncTable<Brand> BrandTable;
        public static IMobileServiceSyncTable<VendorMaster> VendorMasterTable;
        public static IMobileServiceSyncTable<TaxFile> TaxFileTable;
        public static IMobileServiceSyncTable<UOMeasurement> UOMeasurementTable;
        //
        public static IMobileServiceSyncTable<CustomerMaster> CustomermasterTable;
        public static IMobileServiceSyncTable<EmployeeMaster> EmployeemasterTable;
        public static IMobileServiceSyncTable<VendorAddresse> VendorAddressTable;
        public static string Url;


        public async Task Initialize()
        {
            try
            {
                if (Client?.SyncContext?.IsInitialized ?? false)
                    return;
                var appUrl = "http://xamarinprojazureapi.azurewebsites.net";
               // Url = "http://172.31.0.77/XamarinAzure";
                //Create our client

                Client = new MobileServiceClient(appUrl);
                //InitialzeDatabase for path
                var path = "masterdata.db";
                path = Path.Combine(MobileServiceClient.DefaultDatabasePath, path);

                //setup our local sqlite store and intialize our table
                var store = new MobileServiceSQLiteStore(path);

                //Define table
                store.DefineTable<SkuMaster>();
                store.DefineTable<PluMasterPrices>();
                store.DefineTable<Hierarchy_1>();
                store.DefineTable<CustomerMaster>();
                store.DefineTable<Hierarchy_2>();
                store.DefineTable<HierarchyGroup>();
                store.DefineTable<Brand>();
                store.DefineTable<TaxFile>();
                store.DefineTable<VendorMaster>();
                store.DefineTable<UOMeasurement>();
                store.DefineTable<EmployeeMaster>();
                store.DefineTable<VendorAddresse>();

                //Initialize SyncContext
                await Client.SyncContext.InitializeAsync(store);

                //Get our sync table that will call out to azure
                SkuMasterTable = Client.GetTable<SkuMaster>();
                SkuMastertab = Client.GetSyncTable<SkuMaster>();
                pluMasterTable = Client.GetTable<PluMasterPrices>();
                plumastertab = Client.GetSyncTable<PluMasterPrices>();
                HierarchyGroupTable = Client.GetSyncTable<HierarchyGroup>();
                Hierarchy_1Table = Client.GetSyncTable<Hierarchy_1>();
                Hierarchy_2Table = Client.GetSyncTable<Hierarchy_2>();
                BrandTable = Client.GetSyncTable<Brand>();
                VendorMasterTable = Client.GetSyncTable<VendorMaster>();
                TaxFileTable = Client.GetSyncTable<TaxFile>();
                UOMeasurementTable = Client.GetSyncTable<UOMeasurement>();
                CustomermasterTable = Client.GetSyncTable<CustomerMaster>();
                EmployeemasterTable = Client.GetSyncTable<EmployeeMaster>();
                VendorAddressTable = Client.GetSyncTable<VendorAddresse>();
            }
            catch (Exception e)
            {
            }
        }
        //
        public async Task<IEnumerable<PluMasterPrices>> GetMain_PluMasterPrices()
        {
            await Initialize();
            await SyncPluMaster();
            var Master = new PluMasterPrices
            {
                MerchantId = "M001".Trim().ToString(),
            };

            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");
           // var query = plumastertab.CreateQuery().WithParameters(parameters);
           // await plumastertab.PullAsync("SkuMaster", query);
            //var record1 = await pluMasterprices.Where(c => (c.MerchantId == Master.MerchantId.ToString()))
            //    .ToEnumerableAsync();
            var record1 = await pluMasterTable.Where(c => (c.MerchantId == Master.MerchantId.ToString())).ToEnumerableAsync();

            return record1;
        }
        //


        public async Task<IEnumerable<UOMeasurement>> GetMain_UOMAzureAsync()
        {
            await Initialize();
            await SyncUOMMaster();
            var Master = new UOMeasurement
            {
                MerchantId = "M001"
            };

            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");
            var query = UOMeasurementTable.CreateQuery().WithParameters(parameters);
            await UOMeasurementTable.PullAsync("SkuMaster", query);
            var record1 = await UOMeasurementTable.Where(c => (c.MerchantId == Master.MerchantId.ToString()))
                .ToEnumerableAsync();
            return record1;
        }

        //

        public async Task<IEnumerable<CustomerMaster>> GetMain_CustomerAzureAsync()
        {
            await Initialize();
            await SyncCustomerMaster();
            var Master = new CustomerMaster
            {
                MerchantId = "M001"
            };
          /*  var table = Client.GetTable<CustomerMaster>();
            //var record = table.LookupAsync(MerchantId.MerchantId.ToString());
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");

            var query = CustomermasterTablle.CreateQuery().WithParameters(parameters);
            await CustomermasterTablle.PullAsync("SkuMaster", query); */

            var record1 = await CustomermasterTable.Where(c => (c.MerchantId == Master.MerchantId.ToString())).ToEnumerableAsync();
            //BusinessLogicViewModel.H1_Group = record1.ToString();
            return record1;
            //var parameters = new Dictionary<string, string>();
            //parameters.Add("MerchantId", "M001");
            //var query = customermaster.CreateQuery().WithParameters(parameters);
            //await customermaster.PullAsync("SkuMaster", query);
            //var record1 = await customermaster.Where(c => (c.MerchantId == Master.MerchantId.ToString()))
            //    .ToEnumerableAsync();
            //return record1;
        }

        public async Task<IEnumerable<EmployeeMaster>> GetMain_EmployeeAzureAsync()
        {
            await Initialize();
            await SyncEmployeeMaster();
            var Master = new EmployeeMaster
            {
                MerchantId = "M001"
            };
            /*  var table = Client.GetTable<CustomerMaster>();
              //var record = table.LookupAsync(MerchantId.MerchantId.ToString());
              var parameters = new Dictionary<string, string>();
              parameters.Add("MerchantId", "M001");

              var query = CustomermasterTablle.CreateQuery().WithParameters(parameters);
              await CustomermasterTablle.PullAsync("SkuMaster", query); */

            var record1 = await EmployeemasterTable.Where(c => (c.MerchantId == Master.MerchantId.ToString())).ToEnumerableAsync();
            //BusinessLogicViewModel.H1_Group = record1.ToString();
            return record1;
            //var parameters = new Dictionary<string, string>();
            //parameters.Add("MerchantId", "M001");
            //var query = customermaster.CreateQuery().WithParameters(parameters);
            //await customermaster.PullAsync("SkuMaster", query);
            //var record1 = await customermaster.Where(c => (c.MerchantId == Master.MerchantId.ToString()))
            //    .ToEnumerableAsync();
            //return record1;
        }

        public async Task<IEnumerable<VendorAddresse>> GetMain_VendorAddressAzureAsync()
        {
            await Initialize();
            await SyncVendorAddress();
            var Master = new VendorAddresse
            {
                MerchantId = "M001"
            };
            /*  var table = Client.GetTable<CustomerMaster>();
              //var record = table.LookupAsync(MerchantId.MerchantId.ToString());
              var parameters = new Dictionary<string, string>();
              parameters.Add("MerchantId", "M001");

              var query = CustomermasterTablle.CreateQuery().WithParameters(parameters);
              await CustomermasterTablle.PullAsync("SkuMaster", query); */

            var record1 = await VendorAddressTable.Where(c => (c.MerchantId == Master.MerchantId.ToString())).ToEnumerableAsync();
            //BusinessLogicViewModel.H1_Group = record1.ToString();
            return record1;
            //var parameters = new Dictionary<string, string>();
            //parameters.Add("MerchantId", "M001");
            //var query = customermaster.CreateQuery().WithParameters(parameters);
            //await customermaster.PullAsync("SkuMaster", query);
            //var record1 = await customermaster.Where(c => (c.MerchantId == Master.MerchantId.ToString()))
            //    .ToEnumerableAsync();
            //return record1;
        }



        public async Task<IEnumerable<VendorMaster>> GetMain_VendorAzureAsync()
        {
            await Initialize();
          // await SyncVendor();
            var Master = new VendorMaster
            {
                MerchantId = "M001"
            };
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");
            var query = VendorMasterTable.CreateQuery().WithParameters(parameters);
            await VendorMasterTable.PullAsync("allVendorMasters", query);
            var record1 = await VendorMasterTable.Where(c => (c.MerchantId == Master.MerchantId.ToString()))
                .ToEnumerableAsync();
            return record1;
        }
        public async Task<IEnumerable<Brand>> GetMain_AzureBrandAsync()
        {
            await Initialize();
           // await SyncBrandMaster();
            var Master = new Brand
            {
                MerchantId = "M001"
            };
           var table = Client.GetTable<Brand>();
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");

            var query = BrandTable.CreateQuery().WithParameters(parameters);
            await BrandTable.PullAsync("SkuMaster", query);
            var record1 = await BrandTable.Where(c => (c.MerchantId == Master.MerchantId.ToString())).ToEnumerableAsync();
            return record1;
        }
        public async Task<IEnumerable<TaxFile>> GetMain_AzureTaxFileAsync()
        {
            await Initialize();
            //await SyncTaxFileMaster();
            var MerchantId = new TaxFile
            {
                MerchantId = "M001"
            };
            var table = Client.GetTable<TaxFile>();
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");

            var query = TaxFileTable.CreateQuery().WithParameters(parameters);
            await TaxFileTable.PullAsync("SkuMaster", query);
            var record1 = await TaxFileTable.Where(c => (c.MerchantId == MerchantId.MerchantId.ToString())).ToEnumerableAsync();
            return record1;

        }
        //public async Task<IEnumerable<UOMeasurement>> GetMain_AzureUOMAsync()
        //{
        //    await Initialize();
        //    //await SyncUOMMaster();
        //    var MerchantId = new UOMeasurement
        //    {
        //        MerchantId = "M001",
        //    };
        //    var table = Client.GetTable<UOMeasurement>();
        //    var parameters = new Dictionary<string, string>();
        //    parameters.Add("MerchantId", "M001");

        //    var query = UOMeasurementTable.CreateQuery().WithParameters(parameters);
        //    await UOMeasurementTable.PullAsync("SkuMaster", query);
        //    var record1 = await UOMeasurementTable.Where(c => (c.MerchantId == MerchantId.MerchantId.ToString())).ToEnumerableAsync();
        //    return record1;

        //}
        public async Task<IEnumerable<HierarchyGroup>> GetMain_AzureHierarchyGroupAsync()
        {
            await Initialize();
            await SyncHierarchyGroupMaster();
            var MerchantId = new HierarchyGroup
            {
                MerchantId = "M001",
            };
            var table = Client.GetTable<HierarchyGroup>();
            //var record = table.LookupAsync(MerchantId.MerchantId.ToString());
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");

            var query = HierarchyGroupTable.CreateQuery().WithParameters(parameters);
            await HierarchyGroupTable.PullAsync("SkuMaster", query);
            var record1 = await HierarchyGroupTable.Where(c => (c.MerchantId == MerchantId.MerchantId.ToString())).ToEnumerableAsync();
            return record1;
        }
        public async Task<IEnumerable<SkuMaster>> GetMain_SkuMasterAzureAsync(/*string SkuCode*/)
        {
            await Initialize();
            await SyncSkuMaster();
            var Master = new SkuMaster
            {
                MerchantId = "M001".Trim().ToString(),
               // SkuCode = SkuCode
            };

            //var table = Client.GetTable<SkuMaster>();
            //var record = table.LookupAsync(MerchantId.MerchantId.ToString());
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");
          //  parameters.Add("SkuCode", SkuCode);

            //var record1 = await SkuMasterTable.Where(c => (c.MerchantId == Master.MerchantId.ToString())).
            //    Where(c => (c.SkuCode == Master.SkuCode.ToString()))
            //    .ToEnumerableAsync();
            var record1 = await SkuMasterTable.Where(c => (c.MerchantId == Master.MerchantId.ToString())).ToEnumerableAsync();

            return record1;
        }

        public async Task<IEnumerable<Hierarchy_1>> GetMain_AzureHierarchy_1Async()
        {

            await Initialize();
            await SyncHierarchy1Master();
            var MerchantId = new Hierarchy_1
            {
                MerchantId = "M001",
            };
            var table = Client.GetTable<Hierarchy_1>();
            //var record = table.LookupAsync(MerchantId.MerchantId.ToString());
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");

            var query = Hierarchy_1Table.CreateQuery().WithParameters(parameters);
            await Hierarchy_1Table.PullAsync("SkuMaster", query);

            var record1 = await Hierarchy_1Table.Where(c => (c.MerchantId == MerchantId.MerchantId.ToString())).ToEnumerableAsync();
            //BusinessLogicViewModel.H1_Group = record1.ToString();
            return record1;


        }
        public async Task<IEnumerable<Hierarchy_2>> GetMain_AzureHierarchy_2Async()
        {
            await Initialize();
            await SyncHierarchy2Master();

            var MerchantId = new Hierarchy_2
            {
                MerchantId = "M001",
            };

            var table = Client.GetTable<Hierarchy_2>();
            //var record = table.LookupAsync(MerchantId.MerchantId.ToString());
            var parameters = new Dictionary<string, string>();
            parameters.Add("MerchantId", "M001");

            var query = Hierarchy_2Table.CreateQuery().WithParameters(parameters);
            await Hierarchy_2Table.PullAsync("SkuMaster", query);
            var record1 = await Hierarchy_2Table.Where(c => (c.MerchantId == MerchantId.MerchantId.ToString())).ToEnumerableAsync();
            return record1;

        }
        public async void AddHG(Int64 HGCode, Int64 H1Code, Int64 H2Code)
        {
            try { 
                await Initialize();
                HierarchyGroup a = new HierarchyGroup();
                a.HG_Code = HGCode;
                a.MerchantId = "M001";
                a.H1_Code = H1Code;
                a.H2_Code = H2Code;
                a.Id = H1Code.ToString();
                await SaveHGAsync(a);
            }
            catch (Exception e)
            {
            }
        }
        public async void AddH1(Int64 H1Code, string H1Desc)
        {
            try
            {
                await Initialize();
                //var H1 = new Hierarchy_1
                //{
                //    H1_Code = H1Code,
                //    Id = H1Code.ToString(),
                //    MerchantId = "M001",
                //    Description = H1Desc
                //};

                Hierarchy_1 a = new Hierarchy_1();
                a.H1_Code = H1Code;
                a.MerchantId = "M001";
                a.Description = H1Desc;
                a.Id = H1Code.ToString();
                await SaveH1Async(a);
            }
            catch (Exception ee)
            {

            }
            //return H1;
        }
        public async void AddH2(Int64 H2Code, string H2Desc)
        {
            try
            {
                await Initialize();
                Hierarchy_2 a = new Hierarchy_2();
                a.H2_Code = H2Code;
                a.MerchantId = "M001";
                a.Description = H2Desc;
                a.Id = H2Code.ToString();
                await SaveH2Async(a);
            }
            catch (Exception ee)
            {

            }
        }
        public async void AddCustomer(Int64 custCode, string Custname,string contactno,string address1,string address2,string country,string state,string city,string zip,string email)
        {
            try
            {
                await Initialize();
                CustomerMaster a = new CustomerMaster();
                a.Cust_Code = custCode;
                a.MerchantId = "M001";
                a.CardNo = "";
                a.Cust_SurName = "";
                a.Cust_Name = Custname;
                a.Sex = "";
                a.DateOfBirth = DateTime.Now;
                a.Address1 = address1;
                a.Address2 = address2;
                a.City = city;
                a.State = state;
                a.Country = country;
                a.PostCode = zip;
                a.MobileNumber = contactno;
                a.ContactNo2 = "";
                a.ContactNo3 = "";
                a.ContactNo4 = "";
                a.Email = email;
                a.CardActivateOn = DateTime.Now;
                a.Id = custCode.ToString();
                await SaveCustomerAsync(a);
            }
            catch (Exception ee)
            {

            }
        }

        public async void AddEmployee(Int64 EmpCode, string empname, string contactno, string address1, string address2, string country, string state, string city, string zip, string email)
        {
            try
            {
                await Initialize();
                EmployeeMaster a = new EmployeeMaster();
                a.Emp_Code = EmpCode;
                a.MerchantId = "M001";
                a.CardNo = "";
                a.Emp_SurName = "";
                a.Emp_Name = empname;
                a.Sex = "";
                a.DateOfBirth = DateTime.Now;
                a.Address1 = address1;
                a.Address2 = address2;
                a.City = city;
                a.State = state;
                a.Country = country;
                a.PostCode = zip;
                a.MobileNumber = contactno;
                a.ContactNo2 = "";
                a.ContactNo3 = "";
                a.ContactNo4 = "";
                a.Email = email;
                a.CardActivateOn = DateTime.Now;
                a.Id = EmpCode.ToString();
                await SaveEmployeeAsync(a);
            }
            catch (Exception ee)
            {

            }
        }
        public async void AddVendorAddress(Int64 VendoradCode, string contactno, string address1, string address2, string state, string country, string email, string zip)
        {

            try
            {
                await Initialize();
                VendorAddresse a = new VendorAddresse();
                a.VendorCode = VendoradCode;
                a.MerchantId = "M001";
                a.Contact = contactno;
                //a.Contact = "";
                a.Area = address1;
                a.Town = address2;
              //  a.DateOfBirth = DateTime.Now;
               // a.Address1 = address1;
               // a.Address2 = address2;
                a.State = state;
                a.Country = country;
                a.Zip = zip;
                a.Mobile = contactno;
                a.Phones = contactno;
                a.URL = "";
                a.Fax = "";
                a.Email = email;
                a.Id = VendoradCode.ToString();
                await SaveVendorAddressAsync(a);
            }
            catch (Exception ee)
            {

            }
        }
      public async void AddTax(Int64 Code, string Desc)
        {
            try
            {
                await Initialize();
                TaxFile a = new TaxFile();
                a.TaxGrpCode = Code.ToString();
                a.MerchantId = "M001";
                a.TaxGrpDesc = Desc;
                a.Id = Code.ToString();
                await SaveTaxAsync(a);
            }
            catch (Exception ee)
            {

            }
        }
        public async void AddUOM(Int64 Code, string Desc)
        {
            try
            {
                await Initialize();
                UOMeasurement a = new UOMeasurement();
                a.UnitCode = Code;
                a.MerchantId = "M001";
                a.UOM = Desc;
                a.Id = Code.ToString();
                await SaveUOMAsync(a);
            }
            catch (Exception ee)
            {

            }

        }
        public async void AddBrand(Int64 Code, string Desc)
        {
            try
            {
                await Initialize();
                Brand a = new Brand();
                a.BrandCode = Code;
                a.MerchantId = "M001";
                a.BrandDesc = Desc;
                a.Id = Code.ToString();
                await SaveBrandAsync(a);
            }
            catch (Exception ee)
            {

            }

        }
        public async void AddVendor(Int64 Code, string Desc)
        {
            try
            {
                await Initialize();
                VendorMaster a = new VendorMaster();
                a.VendorCode = Code;
                a.MerchantId = "M001";
                a.VendorName = Desc;
                a.Id = Code.ToString();
                await SaveVendorAsync(a);
            }
            catch (Exception ee)
            {

            }
        }
        public async Task SaveHGAsync(HierarchyGroup item)
        {
            try { 
            await HierarchyGroupTable.InsertAsync(item);
        }
            catch (Exception e)
            {
            }
}
        public async Task SaveH1Async(Hierarchy_1 item)
        {
            await Hierarchy_1Table.InsertAsync(item);
        }
        public async Task SaveH2Async(Hierarchy_2 item)
        {
            try { 
            await Hierarchy_2Table.InsertAsync(item);
        }
            catch (Exception e)
            {
            }
}
        public async Task SaveCustomerAsync(CustomerMaster item)
        {
            try
            {
                await CustomermasterTable.InsertAsync(item);
            }
            catch (Exception e)
            {
            }
        }

        public async Task SaveEmployeeAsync(EmployeeMaster item)
        {
            try
            {
                await EmployeemasterTable.InsertAsync(item);
            }
            catch (Exception e)
            {
            }
        }
        public async Task SaveVendorAddressAsync(VendorAddresse item/*,VendorMaster itemm*/)
        {
            try
            {
                await VendorAddressTable.InsertAsync(item);
              //  await VendorMasterTable.InsertAsync(itemm);
            }
            catch (Exception e)
            {
            }
        }


        public async Task SaveVendorAsync(VendorMaster item)
        {
            try { 
            await VendorMasterTable.InsertAsync(item);
        }
            catch (Exception e)
            {
            }
}
        public async Task SaveTaxAsync(TaxFile item)
        {
            try { 
            await TaxFileTable.InsertAsync(item);
        }
            catch (Exception e)
            {
            }
}
        public async Task SaveUOMAsync(UOMeasurement item)
        {
            try { 
            await UOMeasurementTable.InsertAsync(item);
        }
            catch (Exception e)
            {
            }
}

        public async Task SaveBrandAsync(Brand item)
        {
            try { 
            await BrandTable.InsertAsync(item);
        }
            catch (Exception e)
            {
            }
}
        public async Task PushAsync()
        {
            try { 
            Client.SyncContext.PushAsync();
        }
            catch (Exception e)
            {
            }
}
        public async Task SyncHierarchyGroupMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await HierarchyGroupTable.PullAsync("HierarchyGroup", HierarchyGroupTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync HierarchyGroup, that is alright as we have offline capabilities: " + ex);
            }
        }




        public async Task SyncBrandMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await BrandTable.PullAsync("Brand", BrandTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Brand, that is alright as we have offline capabilities: " + ex);
            }
        }
        public async Task SyncVendor()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await VendorMasterTable.PullAsync("allVendorMasters", VendorMasterTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Vendor, that is alright as we have offline capabilities: " + ex);
            }
        }
        //
        public async Task SyncSkuMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await SkuMastertab.PullAsync("SkuMaster", SkuMastertab.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync UOMeasurement, that is alright as we have offline capabilities: " + ex);
            }
        }
        public async Task SyncCustomerMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await CustomermasterTable.PullAsync("customermaster", CustomermasterTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Customer, that is alright as we have offline capabilities: " + ex);
            }
        }

        public async Task SyncEmployeeMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await EmployeemasterTable.PullAsync("employeemaster", EmployeemasterTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Customer, that is alright as we have offline capabilities: " + ex);
            }
        }

        public async Task SyncVendorAddress()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await VendorAddressTable.PullAsync("vendoraddress", VendorAddressTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Customer, that is alright as we have offline capabilities: " + ex);
            }
        }

        public async Task SyncUOMMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await UOMeasurementTable.PullAsync("UOMeasurement", UOMeasurementTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync UOMeasurement, that is alright as we have offline capabilities: " + ex);
            }
        }

        public async Task SyncPluMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await plumastertab.PullAsync("PluMasterPrices", plumastertab.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Plumas, that is alright as we have offline capabilities: " + ex);
            }
        }

        public async Task SyncTaxFileMaster()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await TaxFileTable.PullAsync("TaxFile", TaxFileTable.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync TaxFile, that is alright as we have offline capabilities: " + ex);
            }
        }
        public async Task SyncHierarchy1Master()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await Hierarchy_1Table.PullAsync("Hierarchy_1", Hierarchy_1Table.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Hierarchy_1, that is alright as we have offline capabilities: " + ex);
            }
        }
        public async Task SyncHierarchy2Master()
        {
            try
            {
                //if (!CrossConnectivity.Current.IsConnected)
                //    return;

                await Hierarchy_2Table.PullAsync("Hierarchy_2", Hierarchy_2Table.CreateQuery());

                await Client.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Unable to sync Hierarchy_2, that is alright as we have offline capabilities: " + ex);
            }
        }

    }
}

