using EretailApp.Model;
using EretailApp.ViewModel;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using Plugin.Media;
using SQLite.Net;
using Sqlloginbusinesslogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static EretailApp.LoginForm;

namespace EretailApp
{
    public partial class productMasterConfig : ContentPage
    {

        List<ProductModel> ll = new List<ProductModel>
        {
              new ProductModel
           {
     name="300 ",
                Dept="300",
                category="2017-06-30",
                Icon="ic_user.png",
         },
           new ProductModel
           {
            name="250 ",
                Dept="250",
                category="2017-06-30",
                Icon="ic_user.png",

           }
           ,

             new ProductModel
           {
                name="200 ",
                Dept="200",
                category="2017-06-30",
                Icon="ic_user.png",

           }
             ,
                 new ProductModel
           {
              name="150 ",
                Dept="150",
                category="2017-06-30",
                Icon="ic_user.png",

           }
                 ,

                       new ProductModel
           {
               name="100 ",
                Dept="100",
                category="2017-06-30",
                Icon="ic_user.png",

           }

,

        };




        MasterViewModel vm;
        List<HierarchyGroupDescription> lstHG;
        List<Hierarchy_1> lstH1;
        List<Hierarchy_2> lstH2;
        List<Brand> lstbrand;
        List<VendorMaster> lstvendor;
        List<UOMeasurement> lstUom;
        List<TaxFile> lstTax;
        LoginSuccessResponse result1;
        List<SkuMaster> lst;
        List<PluMasterPrices> lstplu;
        string singleskuqury;
        string skuc;
        public productMasterConfig()
        {
            try
            {
                InitializeComponent();



                if (BusinessLogicViewModel.ListItemValue == "")
                {
                    if (BusinessLogicViewModel.EnableAutoSkucode == "1")
                    {
                        txtSkuCode.IsEnabled = false;
                        txtSkuCode.Text = Convert.ToInt32(BusinessLogicViewModel.LastSkucode + 1).ToString();
                    }
                    else
                    {
                        txtSkuCode.IsEnabled = true;
                    }

                    BindingContext = vm = new MasterViewModel();
                    BindingContext = new SettingsViewModel();
                    EnableDisableFields();
                    // HGList.ItemsSource = BusinessLogicViewModel.GetHierarchy_1().ToList<Hierarchy_1>();
                    //HGList.ItemsSource = BusinessLogicViewModel.GetHG("select H1.Description||','||H2.Description as Description  From HierarchyGroup HG Inner Join Hierarchy_1 H1 on HG.H1_Code = H1.H1_Code Inner Join Hierarchy_2 H2 On HG.H2_Code = H2.H2_Code");
                    lstHG = new List<HierarchyGroupDescription>();
                    lstH1 = new List<Hierarchy_1>();
                    lstH2 = new List<Hierarchy_2>();
                    lstvendor = new List<VendorMaster>();
                    lstUom = new List<UOMeasurement>();
                    lstTax = new List<TaxFile>();
                    lstbrand = new List<Brand>();
                    lstHG = BusinessLogicViewModel.GetHG("select H1.Description||','||H2.Description as Description  From HierarchyGroup HG Inner Join Hierarchy_1 H1 on HG.H1_Code = H1.H1_Code Inner Join Hierarchy_2 H2 On HG.H2_Code = H2.H2_Code").ToList<HierarchyGroupDescription>();
                    lstH1 = BusinessLogicViewModel.GetHierarchy_1().ToList<Hierarchy_1>();
                    lstH2 = BusinessLogicViewModel.GetHierarchy_2().ToList<Hierarchy_2>();
                    lstbrand = BusinessLogicViewModel.GetBrand().ToList<Brand>();
                    lstvendor = BusinessLogicViewModel.GetVendor().ToList<VendorMaster>();
                    lstUom = BusinessLogicViewModel.GetUom().ToList<UOMeasurement>();
                    lstTax = BusinessLogicViewModel.GetTax().ToList<TaxFile>();
                    HGList.ItemsSource = lstHG;

                    H1List.ItemsSource = lstH1;
                    H2List.ItemsSource = lstH2;
                    BrandList.ItemsSource = lstbrand;
                    VendorList.ItemsSource = lstvendor;
                    UomList.ItemsSource = lstUom;
                    TaxList.ItemsSource = lstTax;
                }
                else
                {
                    try
                    {

                        

                         skuc = BusinessLogicViewModel.ListItemValue.Trim();
                        btnmain.Text = "Update";


                        //List<SkuMaster> lst=BusinessLogicViewModel.GetSkumasterDataupdate("select * from )

                        /*    lst = new List<SkuMaster>();

                             lst = BusinessLogicViewModel.GetSkumasterDataupdate("select SkuCode,SKULongName,SKUShortName from skumaster where SkuCode='"+skuc.Trim()+ "'").ToList();
                            foreach (SkuMaster sku in lst)
                            {
                                string s = sku.SkuCode;
                                string s1 = sku.SKULongName;
                                string s2 = sku.SKUShortName;
                                //sku.SkuCode = lst.ToString();
                                //sku.SKULongName = lst.ToString();
                                //sku.SKUShortName = lst.ToString();
                                txtBillDescription.Text = s2;
                                txtSkuCode.Text = s;
                                txtProductDescription.Text = s1;
                                                        lst = BusinessLogicViewModel.GetSingleSku(skuc.Trim(), "Select SkuCode,SKULongName,SKUShortName from SkuMaster where SkuCode='" + skuc.Trim() + "'").ToList<SkuMaster>();

                            }
                            */
                        lst = new List<SkuMaster>();
                        lstplu = new List<PluMasterPrices>();
                        /*
                        lst = BusinessLogicViewModel.GetSingleSku(skuc.Trim(), "Select SkuCode,SKULongName,SKUShortName from SkuMaster where SkuCode='" + skuc.Trim() + "'").ToList<SkuMaster>();
                      */

                        lst = BusinessLogicViewModel.GetSkumasterDataupdate("Select SkuCode,Id,SKULongName,SKUShortName from SkuMaster where SkuCode='" + skuc.Trim() + "'").ToList<SkuMaster>();
                        // lst = BusinessLogicViewModel.GetSkumaster1(skuc).ToList<SkuMaster>();
                        foreach (SkuMaster sku in lst)
                        {
                            string s = sku.SkuCode;
                            string s1 = sku.SKULongName;
                            string s2 = sku.SKUShortName;
                            BusinessLogicViewModel.SkuIdvalue = sku.Id;
                            txtBillDescription.Text = s2;
                            txtSkuCode.Text = s;
                            txtProductDescription.Text = s1;
                        }
                        //select id, title, description from articles inner join users on users.id = articles.id where users.id = 10
                        lstplu = BusinessLogicViewModel.GetPlumasterDataupdate("select PluCode,Id,SkuCode,MRP,SalePrice from PluMasterPrices where SkuCode='" + skuc.Trim() + "'").ToList<PluMasterPrices>();
                        //Int64 SkuExists = BusinessLogicViewModel.GetCode("Select SkuCode,SKULongName,SKUShortName from SkuMaster where SkuCode='" + skuc.Trim() + "'");


                        // BusinessLogicViewModel.GetSkumaster().ToList<SkuMaster>();
                       


                        foreach (PluMasterPrices plu in lstplu)
                        {
                            string s = plu.PluCode;
                            double s1 = plu.MRP;
                            double s2 = plu.SalePrice;
                           BusinessLogicViewModel.PluIdvalue = plu.Id;
                            txtEan.Text = s;
                            txtsales.Text = Convert.ToDouble(s2).ToString();
                            txtMRP.Text = Convert.ToDouble(s1).ToString();
                        }

                        Uri uri = new Uri("https://eretailappp.blob.core.windows.net/fullress/" + txtSkuCode.Text);
                        if(!(String.IsNullOrEmpty(txtSkuCode.Text)))
                        {
                            BlobUpload.GetImage(txtSkuCode.Text);
                            //return;
                            //var container = GetContainer();

                            ////Gets the block blob representing the image
                            //var blob = container.GetBlobReference(txtSkuCode.Text);

                            //if (await blob.ExistsAsync())
                            //{

                            //}
                           
                            if (uri.Equals("https://eretailappp.blob.core.windows.net/fullress/" + txtSkuCode.Text))
                            {
                                camicon.IsVisible = false;
                                BusinessLogicViewModel.CamOpen = camicon.IsVisible=true;
                                cam.IsVisible = true;
                                cam.Source = ImageSource.FromUri(uri);
                            }
                            else
                            {
                                cam.IsVisible = false;
                                camicon.IsVisible = true;
                            }
                        }
                        else
                        {
                            cam.IsVisible = false;
                            camicon.IsVisible = true;
                        }
                        //var img = new Image
                        //{
                        //    Source = ImageSource.FromUri(uri),
                        //    WidthRequest = 70

                        //};



                    }
                            catch (Exception ee)
                            {
                                DisplayAlert("Skumater single query error", ee.Message, "Ok");
                            }


                        }
                    }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }

            //BrandPicker.ItemsSource= BusinessLogicViewModel.GetBrand().ToList<Brand>();
        }
        private CloudBlobContainer GetContainer()
        {
            const string connectionString = "DefaultEndpointsProtocol=https;AccountName=eretailappp;AccountKey=lvwFbagHFfDZNN3mY6HaBqh2lHsfLl1H9UZRgfy5tFHzT8MqVTTm9aD+ZdMlKot0a6OUNHhIxMg0BSmF4uTTvg==;";

            // Parses the connection string for the WindowS Azure Storage Account
            var account = CloudStorageAccount.Parse(connectionString);
            var client = account.CreateCloudBlobClient();

            // Gets a reference to the images container
            var container = client.GetContainerReference("fullress");

            return container;
        }

        async void camera()
        {
            try
            {
                await CrossMedia.Current.Initialize();
                if (!(CrossMedia.Current.IsCameraAvailable || CrossMedia.Current.IsTakePhotoSupported))
                {

                    await DisplayAlert("Not Available", "Don't have Camera", "OK", "Ok");
                    return;
                }

                var mediafile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {

                    Directory = "sample",
                    Name = "hi.png"
                });
                if (mediafile == null)
                {
                    return;
                }
                if (!(String.IsNullOrEmpty(txtSkuCode.Text))) { 

                            BusinessLogicViewModel.CameraSkuCode = txtSkuCode.Text.ToString();

                    //await BlobS.Instance.Uploadfileasync(mediafile.Path);

                    Stream aw = mediafile.GetStream();

                    // showstatus("uploading image.........", true);
                    await BlobUpload.UploadImage(aw);
                    DisplayAlert("OH!", "Image Uploaded SucessFullly", "Ok");
                }
            
            else
            {
                DisplayAlert("Alert", "Skucode Should not Empty", "Ok", "Cancel");
            }

        }
            catch (Exception e)
            {
                DisplayAlert("Oops", e.Message, "Ok", "Cancel");

            }
        }

        public async void gallery()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                await DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return;
            }
            var file = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = Plugin.Media.Abstractions.PhotoSize.Medium
            });


            if (file == null)
                return;
            if (!(String.IsNullOrEmpty(txtSkuCode.Text)))
            {
                BusinessLogicViewModel.CameraSkuCode = txtSkuCode.Text.ToString();

                //await BlobS.Instance.Uploadfileasync(mediafile.Path);

                Stream aw = file.GetStream();

                // showstatus("uploading image.........", true);
                await BlobUpload.UploadImage(aw);
            }
            else
            {
                DisplayAlert("Alert","Skucode Should not Empty","Ok","Cancel");
            }
            //img.Source = ImageSource.FromStream(() =>
            //{
            //    var stream = file.GetStream();
            //    file.Dispose();
            //    return stream;
            //});

        }




        public void EnableDisableFields()
        {
            try
            {
                if (BusinessLogicViewModel.EnableHierarchyGroup == "0")
                {
                    txtHierarchyLevel.IsVisible = false;
                    lblproductlvl.IsVisible = false;
                    imgproductlvl.IsVisible = false;
                }
                else
                {
                    txtHierarchyLevel.IsVisible = true;
                    lblproductlvl.IsVisible = true;
                    imgproductlvl.IsVisible = true;
                }
                if (BusinessLogicViewModel.EnableH1 == "0")
                {
                    DeptSl.IsVisible = false;
                    H1List.IsVisible = false;
                }
                else
                {
                    DeptSl.IsVisible = true;
                    H1List.IsVisible = true;
                }
                if (BusinessLogicViewModel.EnableH2 == "0")
                {
                    CatgSl.IsVisible = false;
                    H2List.IsVisible = false;
                }
                else
                {
                    CatgSl.IsVisible = true;
                    H2List.IsVisible = true;
                }
                if (BusinessLogicViewModel.EnableH1 == "0" && BusinessLogicViewModel.EnableH2 == "0")
                {
                    txtHierarchyLevel.IsVisible = false;
                    lblproductlvl.IsVisible = false;
                    imgproductlvl.IsVisible = false;

                }
                else
                {
                    txtHierarchyLevel.IsVisible = true;
                    lblproductlvl.IsVisible = true;
                    imgproductlvl.IsVisible = true;
                }
                if (BusinessLogicViewModel.EnableUOM == "0")
                {
                    entryUom.Text = "No's";
                    imgUom.IsVisible = false;

                }
                else
                {
                    entryUom.Placeholder = "Enter UOM";
                    imgUom.IsVisible = true;
                }

                if (BusinessLogicViewModel.EnableTax == "0")
                {
                    entryTax.Text = "0%";
                    imgtax.IsVisible = false;
                }
                else
                {
                    entryTax.Placeholder = "Enter Tax";
                    imgtax.IsVisible = true;
                }

                if (BusinessLogicViewModel.EnableMarkUp == "0")
                {
                    txtMarkUpDown.Placeholder = "Enter Mark Down";
                    labelMark.Text = "Mark Down";
                }
                else
                {
                    txtMarkUpDown.Placeholder = "Enter Mark Up";
                    labelMark.Text = "Mark Up";
                }
                if (BusinessLogicViewModel.EnableBrand == "0")
                {
                    imgBrand.IsVisible = false;
                }
                else
                {
                    imgBrand.IsVisible = true;
                    //BrandPicker.IsVisible = true;
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void back(Object o, EventArgs e)
        {
            try
            {
                Navigation.PushModalAsync(new MainPage());
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }


        public void hgclick(Object o, EventArgs e)
        {
            try
            {
                HgCv.IsVisible = true;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }



        public void H1addpopupClick(Object o, EventArgs e)
        {
            try
            {
                H1Addpop.IsVisible = true;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }


        public void H1AddpopCancel(Object o, EventArgs e)
        {
            try
            {
                H1Addpop.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }


        public void H1AddpopSave(Object o, EventArgs e)
        {
            try
            {
                Int64 Hierarchy_1DescriptionExists = BusinessLogicViewModel.GetCode("Select Description from Hierarchy_1 Where Description='" + AddnewtxtH1popup.Text + "'");
                if (Hierarchy_1DescriptionExists == 0)
                {
                     Hierarchy_1DescriptionExists = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(Description as int)),0) as Description from Hierarchy_1");
                    //BrandCode++;
                    //BusinessLogicViewModel.InsertAddBrand(BrandCode, txtBrand.Text);
                    //txtBrand.Text = AddnewtxtBrand.Text;
                    //AddnewtxtBrand.Text = "";
                    txtH1.Text = AddnewtxtH1popup.Text;

                    //  DisplayAlert("Alert", " Department alredy not  exists", "Ok");
                    AddnewtxtH1popup.Text = "";
                    H1Addpop.IsVisible = false;

                }
                else if (Hierarchy_1DescriptionExists > 0)
                {
                    string H1addpopupTxt = AddnewtxtH1popup.Text;
                    txtH1.Text = H1addpopupTxt;
                    AddnewtxtH1popup.Text = "";
                    // DisplayAlert("Alert", " Department alredy exists ", "Ok");
                    H1Addpop.IsVisible = false;
                }




                //  string H1addpopupTxt= AddnewtxtH1popup.Text.ToString();
                H1Addpop.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }




        public void H2addpopupClick(Object o, EventArgs e)
        {
            try
            {
                H2Addpop.IsVisible = true;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }


        public void H2AddpopCancel(Object o, EventArgs e)
        {
            try
            {
                H2Addpop.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }


        public void H2AddpopSave(Object o, EventArgs e)
        {
            try
            {

                Int64 Hierarchy_2DescriptionExists = BusinessLogicViewModel.GetCode("Select Description from Hierarchy_2  Where Description='" + AddnewtxtH2popup.Text + "'");
                if (Hierarchy_2DescriptionExists == 0)
                {
                    Hierarchy_2DescriptionExists = BusinessLogicViewModel.GetCode("Select IfNull(Max(Description),0) as Description from Hierarchy_2");
                    //BrandCode++;
                    //BusinessLogicViewModel.InsertAddBrand(BrandCode, txtBrand.Text);
                    //txtBrand.Text = AddnewtxtBrand.Text;
                    //AddnewtxtBrand.Text = "";
                    txtH2.Text = AddnewtxtH2popup.Text;

                    //  DisplayAlert("Alert", " Department alredy not  exists", "Ok");
                    AddnewtxtH2popup.Text = "";
                    H2Addpop.IsVisible = false;

                }
                else if (Hierarchy_2DescriptionExists > 0)
                {
                    string H2addpopupTxt = AddnewtxtH2popup.Text;
                    txtH2.Text = H2addpopupTxt;
                    AddnewtxtH2popup.Text = "";
                    // DisplayAlert("Alert", " Department alredy exists ", "Ok");
                    H2Addpop.IsVisible = false;
                }

               H2Addpop.IsVisible = false;


                
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }






        public void hgpopd(Object o, EventArgs e)
        {
            try
            {
                txtH1.Text = "";
                txtH2.Text = "";
                Hgpop.IsVisible = true;
                HgCv.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void hgpopdcanel(Object o, EventArgs e)
        {
            try
            {
                Hgpop.IsVisible = false;
                HgCv.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void OnHGItemSelected(Object o, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (HierarchyGroupDescription)e.SelectedItem;
                txtHierarchyLevel.Text = item.Description.ToString();
                if (txtHierarchyLevel.Text != "")
                {
                    HgCv.IsVisible = false;
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void OnHG1ItemSelected(Object o, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (Hierarchy_1)e.SelectedItem;
                txtH1.Text = item.Description.ToString();
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }

        }


        public void OnBrandItemSelected(Object o, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (Brand)e.SelectedItem;
                txtBrand.Text = item.BrandDesc.ToString();
                if (txtBrand.Text != "")
                {
                    BrandCv.IsVisible = false;
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void OnVendorItemSelected(Object o, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (VendorMaster)e.SelectedItem;
                txtVendor.Text = item.VendorName.ToString();
                if (txtVendor.Text != "")
                {
                    vendorCv.IsVisible = false;
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void OnUomItemSelected(Object o, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (UOMeasurement)e.SelectedItem;
                entryUom.Text = item.UOM.ToString();
                if (entryUom.Text != "")
                {
                    UomCv.IsVisible = false;
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void OnTaxItemSelected(Object o, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (TaxFile)e.SelectedItem;
                entryTax.Text = item.TaxGrpDesc.ToString();
                if (entryTax.Text != "")
                {
                    TaxCv.IsVisible = false;
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

        public void AddnewBrand(Object o, EventArgs e)
        {
            try
            {
                BrandCv.IsVisible = false;
                Brandpop.IsVisible = true;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void btnCancelBrand(Object o, EventArgs e)
        {
            try
            {
                BrandCv.IsVisible = false;
                Brandpop.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }




        public void DiscOnMRP(Object o, EventArgs e)
        {
            DMRPCv.IsVisible = true;
            DMRPList.ItemsSource = ll;

        }


        public void DiscMrpClose(Object o, EventArgs e)
        {
            DMRPCv.IsVisible = false;


        }

        public void OndiscountItemSelected(Object o, SelectedItemChangedEventArgs e)
        {

            DMRPCv.IsVisible = false;



        }



        public void btnSaveBrand(Object o, EventArgs e)
        {
            try
            {
                //Int64 BrandCodeExists = BusinessLogicViewModel.GetCode("Select BrandCode from Brand  Where BrandDesc='" + AddnewtxtBrand.Text + "'");
                //if (BrandCodeExists == 0)
                //{
                //    Int64 BrandCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(BrandCode),0) as BrandCode from Brand");
                //    BrandCode++;
                //    BusinessLogicViewModel.InsertAddBrand(BrandCode, AddnewtxtBrand.Text);
                //    txtBrand.Text = AddnewtxtBrand.Text;
                //    AddnewtxtBrand.Text = "";

                //}
                //else
                //{
                //    DisplayAlert("Alert", "Already " + AddnewtxtBrand.Text + " Exists", "Ok");
                //}
                txtBrand.Text = AddnewtxtBrand.Text;
                AddnewtxtBrand.Text = "";
                BrandCv.IsVisible = false;
                Brandpop.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

        public void SearchHG(Object o, TextChangedEventArgs e)
        {
            try
            {

                //IEnumerable<HierarchyGroupDescription> searchresult = lstHG.Where(name1 => name1.Description.Contains(searchhg.Text));
                //HGList.ItemsSource = searchresult;


                HGList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    HGList.ItemsSource = lstHG;
                else
                    HGList.ItemsSource = lstHG.Where(i => i.Description.ToLower().Contains(e.NewTextValue.ToLower()));

                HGList.EndRefresh();
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }





        public void SearchBrand(Object o, TextChangedEventArgs e)
        {
            try
            {

                //IEnumerable<Brand> searchresult = lstbrand.Where(name1 => name1.BrandDesc.Contains(searchbrand.Text));
                //BrandList.ItemsSource = searchresult;

                /* */

                BrandList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    BrandList.ItemsSource = lstbrand;
                else
                    BrandList.ItemsSource = lstbrand.Where(i => i.BrandDesc.ToLower().Contains(e.NewTextValue.ToLower()));

                BrandList.EndRefresh();


                /* */


            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }


        public void AddnewVendor(Object o, EventArgs e)
        {

            vendorCv.IsVisible = false;
            Vendorpop.IsVisible = true;
        }


        public void btnCancelVendor(Object o, EventArgs e)
        {

            vendorCv.IsVisible = false;
            Vendorpop.IsVisible = false;
        }
        public void btnSaveVendor(Object o, EventArgs e)
        {
            try
            {
                //Int64 VendorCodeExists = BusinessLogicViewModel.GetCode("Select VendorCode from VendorMaster  Where VendorName='" + AddnewtxtVendor.Text + "'");
                //if (VendorCodeExists == 0)
                //{
                //    Int64 VendorCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(VendorCode),0) as VendorCode from VendorMaster");
                //    VendorCode++;
                 //  BusinessLogicViewModel.InsertAddVendor(VendorCode, AddnewtxtVendor.Text);
                //    txtVendor.Text = AddnewtxtVendor.Text;
                //    AddnewtxtVendor.Text = "";
                //}
                //else
                //{
                //    DisplayAlert("Alert", "Already " + AddnewtxtVendor.Text + " Exists", "Ok");

                //}
                txtVendor.Text = AddnewtxtVendor.Text;
                AddnewtxtVendor.Text = "";
                vendorCv.IsVisible = false;
                Vendorpop.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

        public void SearchVendor(Object o, TextChangedEventArgs e)
        {
            try
            {

                VendorList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    VendorList.ItemsSource = lstvendor;
                else
                    VendorList.ItemsSource = lstvendor.Where(i => i.VendorName.ToLower().Contains(e.NewTextValue.ToLower()));

                VendorList.EndRefresh();

                //IEnumerable<VendorMaster> searchresult = lstvendor.Where(name1 => name1.VendorName.Contains(searchvendor.Text));
                //VendorList.ItemsSource = searchresult;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

        public void AddnewUom(Object o, EventArgs e)
        {
            try
            {
                //Int64 UOMCodeExists = BusinessLogicViewModel.GetCode("Select UnitCode from UOMeasurement  Where UOM='" + AddnewtxtUom.Text + "'");
                //if (UOMCodeExists == 0)
                //{
                //    Int64 UOMCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(UnitCode),0) as UnitCode from UOMeasurement");
                //    UOMCode++;
                //    BusinessLogicViewModel.InsertAddUOM(UOMCode, AddnewtxtUom.Text);
                //    entryUom.Text = AddnewtxtUom.Text;
                //    AddnewtxtUom.Text = "";
                //}
                //else
                //{
                //    DisplayAlert("Alert", "Already " + AddnewtxtUom.Text + " Exists", "Ok");

                //}
                //   entryUom.Text = AddnewtxtUom.Text;
                //AddnewtxtUom.Text = "";
                UomCv.IsVisible = false;
                Uompop.IsVisible = true;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void btnCancelUom(Object o, EventArgs e)
        {

            UomCv.IsVisible = false;
            Uompop.IsVisible = false;
        }
        public void btnSaveUom(Object o, EventArgs e)
        {

            entryUom.Text = AddnewtxtUom.Text;
            AddnewtxtUom.Text = "";

            UomCv.IsVisible = false;
            Uompop.IsVisible = false;
        }
        public void SearchUom(Object o, TextChangedEventArgs e)
        {
            try
            {

                //IEnumerable<UOMeasurement> searchresult = lstUom.Where(name1 => name1.UOM.Contains(searchUom.Text));
                //BrandList.ItemsSource = searchresult;


                UomList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    UomList.ItemsSource = lstUom;
                else
                    UomList.ItemsSource = lstUom.Where(i => i.UOM.ToLower().Contains(e.NewTextValue.ToLower()));

                UomList.EndRefresh();

            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void SearchH1(Object o, TextChangedEventArgs e)
        {
            try
            {


                H1List.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    H1List.ItemsSource = lstH1;
                else
                    H1List.ItemsSource = lstH1.Where(i => i.Description.ToLower().Contains(e.NewTextValue.ToLower()));

                H1List.EndRefresh();
                //IEnumerable<Hierarchy_1> searchresult = lstH1.Where(name1 => name1.Description.Contains(txtH1.Text));
                //H1List.ItemsSource = searchresult;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void AddnewTax(Object o, EventArgs e)
        {

            TaxCv.IsVisible = false;
            Taxpop.IsVisible = true;
        }

        public void btnCancelTax(Object o, EventArgs e)
        {

            TaxCv.IsVisible = false;
            Taxpop.IsVisible = false;
        }
        public void btnSaveTax(Object o, EventArgs e)
        {
            entryTax.Text = AddnewtxtTax.Text;
            AddnewtxtTax.Text = "";

            TaxCv.IsVisible = false;
            Taxpop.IsVisible = false;
        }
        public void SearchTax(Object o, TextChangedEventArgs e)
        {
            try
            {

                //IEnumerable<TaxFile> searchresult = lstTax.Where(name1 => name1.TaxGrpDesc.Contains(searchtax.Text));
                //TaxList.ItemsSource = searchresult;



                TaxList.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    TaxList.ItemsSource = lstTax;
                else
                    TaxList.ItemsSource = lstTax.Where(i => i.TaxGrpDesc.ToLower().Contains(e.NewTextValue.ToLower()));

                TaxList.EndRefresh();

            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

        public void SearchH2(Object o, TextChangedEventArgs e)
        {
            try
            {



                H2List.BeginRefresh();

                if (string.IsNullOrWhiteSpace(e.NewTextValue))
                    H2List.ItemsSource = lstH2;
                else
                    H2List.ItemsSource = lstH2.Where(i => i.Description.ToLower().Contains(e.NewTextValue.ToLower()));

                H2List.EndRefresh();

                //IEnumerable<Hierarchy_2> searchresult = lstH2.Where(name1 => name1.Description.Contains(txtH2.Text));
                //H2List.ItemsSource = searchresult;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public void OnHG2ItemSelected(Object o, SelectedItemChangedEventArgs e)
        {
            try
            {
                var item = (Hierarchy_2)e.SelectedItem;
                txtH2.Text = item.Description.ToString();
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void entryUOMclk(object sender, EventArgs e)
        {
            Hgpop.IsVisible = true;
        }
        private async void btnMainSaveClick(object sender, EventArgs e)
        {
            btnSaveProduct.IsEnabled = false;
            try
            {
                if (!(skuc.Equals(BusinessLogicViewModel.ListItemValue)))
                {

                    //if (!BusinessLogicViewModel.CheckConnection)
                    //{
                    //    DisplayAlert("Alert", "Unable to connect to internet ", "Ok");
                    //    return;
                    //}
                    if (String.IsNullOrEmpty(txtSkuCode.Text))
                    {
                        txtSkuCode.Focus();
                        DisplayAlert("Alert", "Please Enter SkuCode ", "Ok"); return;
                    }
                    if (String.IsNullOrEmpty(txtProductDescription.Text))
                    {
                        txtProductDescription.Focus();
                        DisplayAlert("Alert", "Please Enter ProductDescription ", "Ok"); return;
                    }
                    if (String.IsNullOrEmpty(txtBillDescription.Text))
                    {
                        txtBillDescription.Focus();
                        DisplayAlert("Alert", "Please Enter BillDescription ", "Ok"); return;
                    }

                    //
                    if (String.IsNullOrEmpty(txtCostPrice.Text))
                    {
                        txtCostPrice.Focus(); DisplayAlert("Alert", "Please Enter CostPrice ", "Ok"); return;
                    }
                    //sudha 
                    //    else
                    //{
                    //    txtCostPrice.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtCostPrice);
                    //}
                    //if (!String.IsNullOrEmpty(txtsales.Text))
                    //{
                    //    if (!(double.Parse(txtCostPrice.Text) < double.Parse(txtsales.Text)))
                    //    {
                    //        DisplayAlert("Hey!", "Sales Price Cannot be Less than Cost Price", "Ok");
                    //    }
                    //}
                    //sudha

                    //


                    //

                    if (String.IsNullOrEmpty(txtMRP.Text))
                    {
                        DisplayAlert("Error", "Enter MRP", "Ok");
                        return;
                    }
                    //sudha
                    //else
                    //{
                    //    txtMRP.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtMRP);
                    //}
                    //if (!String.IsNullOrEmpty(txtMRP.Text))
                    //{
                    //    if (!(double.Parse(txtCostPrice.Text) <= double.Parse(txtMRP.Text)))
                    //    {
                    //        DisplayAlert("Error", "MRP Cannot be Less Than Cost Price", "Ok");
                    //    }
                    //}
                    //sudha

                    //






                    if (String.IsNullOrEmpty(txtMarkUpDown.Text))
                    {
                        txtMarkUpDown.Focus();
                        if (BusinessLogicViewModel.EnableMarkUp == "1")
                        {
                            DisplayAlert("Alert", "Please Enter MarkUp ", "Ok"); return;
                        }
                        else if (BusinessLogicViewModel.EnableHierarchyGroup == "0")
                        {
                            DisplayAlert("Alert", "Please Enter MarkDown ", "Ok"); return;
                        }
                    }
                    if (String.IsNullOrEmpty(txtHSNCode.Text))
                    {
                        txtHSNCode.Focus(); DisplayAlert("Alert", "Please Enter HSNCode ", "Ok"); return;
                    }
                    if (BusinessLogicViewModel.EnableHierarchyGroup == "1")
                    {
                        if (String.IsNullOrEmpty(txtHierarchyLevel.Text))
                        {
                            txtHierarchyLevel.Focus();
                            DisplayAlert("Alert", "Please Select Hierarchy Level ", "Ok"); return;
                        }
                    }
                    if (BusinessLogicViewModel.EnableBrand == "1")
                    {
                        if (String.IsNullOrEmpty(txtBrand.Text))
                        {
                            txtBrand.Focus(); DisplayAlert("Alert", "Please Select or Enter Brand ", "Ok"); return;
                        }
                    }
                    if (BusinessLogicViewModel.EnableTax == "1")
                    {
                        if (String.IsNullOrEmpty(entryTax.Text))
                        {
                            entryTax.Focus(); DisplayAlert("Alert", "Please Select or Enter Tax ", "Ok");
                            return;
                        }
                    }
                    if (BusinessLogicViewModel.EnableUOM == "1")
                    {
                        if (String.IsNullOrEmpty(entryUom.Text))
                        {
                            DisplayAlert("Alert", "Please Select or Enter UOM ", "Ok");
                            entryUom.Focus(); return;
                        }
                    }
                    
                    var client = new System.Net.Http.HttpClient();
                     // var response = await client.GetAsync(new Uri("http://172.31.0.77/XamarinAzure/tables/SkuMaster?ZUMO-API-VERSION=2.0.0&SkuCode=" + txtSkuCode.Text));
                     var response = await client.GetAsync(new Uri("http://xamarinprojazureapi.azurewebsites.net/tables/SkuMaster?ZUMO-API-VERSION=2.0.0&SkuCode=" + txtSkuCode.Text));



                     if (response.IsSuccessStatusCode)
                     {
                         var result1 = JsonConvert.DeserializeObject<List<SkuMaster>>(response.Content.ReadAsStringAsync().Result);
                         if (result1.Count == 1)
                         {
                             DisplayAlert("Alert", "SkuCode already exists " + txtSkuCode.Text, "Ok");
                             return;
                         }
                     }
                     else
                     {
                         DisplayAlert("Alert", "ServerStatus Code :" + response.IsSuccessStatusCode.ToString(), "Ok");
                         return;
                     }
                    HgCv.IsVisible = false;
                    SkuMaster sm = new SkuMaster();
                    sm.MerchantId = "M001";
                    sm.SkuCode = txtSkuCode.Text;
                    sm.SKUShortName = txtBillDescription.Text;
                    sm.SKULongName = txtProductDescription.Text;
                    sm.GroupCode = 1;
                    if (BusinessLogicViewModel.EnableBrand == "1")
                    {
                        sm.HG_Code = 0;
                    }
                    else
                    {
                        sm.HG_Code = 0;
                    }
                    if (BusinessLogicViewModel.EnableBrand == "1")
                    {
                        sm.BrandCode = BusinessLogicViewModel.GetCode("Select BrandCode from Brand Where BrandDesc='" + txtBrand.Text + "'");
                    }
                    else
                    {
                        sm.BrandCode = 0;
                    }
                    sm.MfgCode = 1;
                    if (BusinessLogicViewModel.EnableTax == "1")
                    {
                        sm.TaxGrpCode = "";// BusinessLogicViewModel.GetCode("Select TaxGrpCode from TaxFile Where TaxGrpName='" + Convert.ToInt32(txtBrand.Text) + "'");//"TG1";
                    }
                    else
                    {
                        sm.TaxGrpCode = "";
                    }
                    sm.UnitCode = 1;
                    if (swOpenRate.IsToggled == true)
                        sm.OpenRate = true;
                    else
                        sm.OpenRate = false;
                    sm.Kit = false;
                    sm.Discountable = false;
                    sm.ConsiderBulk = false;
                    if (swMaintainInventory.IsToggled == true)
                        sm.NonInv = true;
                    else
                        sm.NonInv = false;
                    sm.SkuType = "NF";
                    sm.CaseQty = 0;
                    sm.InnerCaseQty = 0;
                    sm.Qoh = Convert.ToDouble(txtQOH.Text);
                    sm.EanNumber = false;
                    if (swAllowOnlyDecimal.IsToggled == true)
                        sm.AllowDecimal = true;
                    else
                        sm.AllowDecimal = false;
                    sm.HSNCode = ""; //BusinessLogicViewModel.GetCode("Select HG_Code as MaxCode from Hierarchy_1 Where ");
                    sm.ChangeBy = "Admin";
                    sm.CreatedBy = "Admin";
                    sm.LastUpdated = DateTime.Now;
                    sm.CreatedDate = DateTime.Now;
                    PluMasterPrices pluMasterPrices = new PluMasterPrices();
                    pluMasterPrices.MerchantId = "M001";
                    pluMasterPrices.SkuCode = txtSkuCode.Text;
                    pluMasterPrices.PluCode = txtEan.Text;
                    pluMasterPrices.PluPriceCode = "";
                    pluMasterPrices.Priority = 0;
                    pluMasterPrices.DealerSP = 0;
                    pluMasterPrices.MRP = Convert.ToDouble(txtMRP.Text);
                    pluMasterPrices.SalePrice = Convert.ToDouble(txtsales.Text);
                    pluMasterPrices.PluCode = txtEan.Text;
                    pluMasterPrices.LastUpDated = DateTime.Now;
                    pluMasterPrices.Inactive = false;
                    BusinessLogicViewModel.SaveTaskAsync(sm, pluMasterPrices);
                    btnSaveProduct.IsEnabled = true;
                    Int64 VendorCodeExists = BusinessLogicViewModel.GetCode("Select VendorCode from VendorMaster  Where VendorName='" + txtVendor.Text + "'");
                    if (VendorCodeExists == 0)
                    {
                        Int64 VendorCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(VendorCode as int)),0) as VendorCode from VendorMaster");
                        VendorCode++;
                        BusinessLogicViewModel.InsertAddVendor(VendorCode, txtVendor.Text);
                    }
                    Int64 UOMCodeExists = BusinessLogicViewModel.GetCode("Select UnitCode from UOMeasurement  Where UOM='" + entryUom.Text + "'");
                    if (UOMCodeExists == 0)
                    {
                        Int64 UOMCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(UnitCode as int)),0) as UnitCode from UOMeasurement");
                        UOMCode++;
                        BusinessLogicViewModel.InsertAddUOM(UOMCode, entryUom.Text);
                    }
                    Int64 BrandCodeExists = BusinessLogicViewModel.GetCode("Select BrandCode from Brand  Where BrandDesc='" + txtBrand.Text + "'");
                    if (BrandCodeExists == 0)
                    {
                        Int64 BrandCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(BrandCode as int)),0) as BrandCode from Brand");
                        BrandCode++;
                        BusinessLogicViewModel.InsertAddBrand(BrandCode, txtBrand.Text);
                        txtBrand.Text = AddnewtxtBrand.Text;
                        AddnewtxtBrand.Text = "";

                    }
                    Int64 TaxGrpCodeExists = BusinessLogicViewModel.GetCode("Select TaxGrpCode from TaxFile  Where TaxGrpDesc='" + entryTax.Text + "'");
                    if (TaxGrpCodeExists == 0)
                    {
                        Int64 TaxCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(TaxGrpCode as int)),0) as TaxGrpCode from TaxFile");
                        TaxCode++;
                        BusinessLogicViewModel.InsertAddTax(TaxCode, entryTax.Text);
                        entryTax.Text = AddnewtxtTax.Text;
                        AddnewtxtTax.Text = "";

                    }

                    BusinessLogicViewModel.PushLocalData();
                    ClearFields();
                    if (BusinessLogicViewModel.EnableAutoSkucode == "1")
                    {
                        GetAutoSkuCode();
                    }

                }
                else
                {
                    //ss
                    txtSkuCode.IsEnabled = false;
                    if (String.IsNullOrEmpty(txtSkuCode.Text))
                    {
                        txtSkuCode.Focus();
                        DisplayAlert("Alert", "Please Enter SkuCode ", "Ok"); return;
                    }
                    if (String.IsNullOrEmpty(txtProductDescription.Text))
                    {
                        txtProductDescription.Focus();
                        DisplayAlert("Alert", "Please Enter ProductDescription ", "Ok"); return;
                    }
                    if (String.IsNullOrEmpty(txtBillDescription.Text))
                    {
                        txtBillDescription.Focus();
                        DisplayAlert("Alert", "Please Enter BillDescription ", "Ok"); return;
                    }

                    //
                    if (String.IsNullOrEmpty(txtCostPrice.Text))
                    {
                        txtCostPrice.Focus(); DisplayAlert("Alert", "Please Enter CostPrice ", "Ok"); return;
                    }
                    //sudha 
                    //    else
                    //{
                    //    txtCostPrice.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtCostPrice);
                    //}
                    //if (!String.IsNullOrEmpty(txtsales.Text))
                    //{
                    //    if (!(double.Parse(txtCostPrice.Text) < double.Parse(txtsales.Text)))
                    //    {
                    //        DisplayAlert("Hey!", "Sales Price Cannot be Less than Cost Price", "Ok");
                    //    }
                    //}
                    //sudha

                    //


                    //

                    if (String.IsNullOrEmpty(txtMRP.Text))
                    {
                        DisplayAlert("Error", "Enter MRP", "Ok");
                        return;
                    }
                    //sudha
                    //else
                    //{
                    //    txtMRP.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtMRP);
                    //}
                    //if (!String.IsNullOrEmpty(txtMRP.Text))
                    //{
                    //    if (!(double.Parse(txtCostPrice.Text) <= double.Parse(txtMRP.Text)))
                    //    {
                    //        DisplayAlert("Error", "MRP Cannot be Less Than Cost Price", "Ok");
                    //    }
                    //}
                    //sudha

                    //






                    if (String.IsNullOrEmpty(txtMarkUpDown.Text))
                    {
                        txtMarkUpDown.Focus();
                        if (BusinessLogicViewModel.EnableMarkUp == "1")
                        {
                            DisplayAlert("Alert", "Please Enter MarkUp ", "Ok"); return;
                        }
                        else if (BusinessLogicViewModel.EnableHierarchyGroup == "0")
                        {
                            DisplayAlert("Alert", "Please Enter MarkDown ", "Ok"); return;
                        }
                    }
                    if (String.IsNullOrEmpty(txtHSNCode.Text))
                    {
                        txtHSNCode.Focus(); DisplayAlert("Alert", "Please Enter HSNCode ", "Ok"); return;
                    }
                    if (BusinessLogicViewModel.EnableHierarchyGroup == "1")
                    {
                        if (String.IsNullOrEmpty(txtHierarchyLevel.Text))
                        {
                            txtHierarchyLevel.Focus();
                            DisplayAlert("Alert", "Please Select Hierarchy Level ", "Ok"); return;
                        }
                    }
                    if (BusinessLogicViewModel.EnableBrand == "1")
                    {
                        if (String.IsNullOrEmpty(txtBrand.Text))
                        {
                            txtBrand.Focus(); DisplayAlert("Alert", "Please Select or Enter Brand ", "Ok"); return;
                        }
                    }
                    if (BusinessLogicViewModel.EnableTax == "1")
                    {
                        if (String.IsNullOrEmpty(entryTax.Text))
                        {
                            entryTax.Focus(); DisplayAlert("Alert", "Please Select or Enter Tax ", "Ok");
                            return;
                        }
                    }
                    if (BusinessLogicViewModel.EnableUOM == "1")
                    {
                        if (String.IsNullOrEmpty(entryUom.Text))
                        {
                            DisplayAlert("Alert", "Please Select or Enter UOM ", "Ok");
                            entryUom.Focus(); return;
                        }
                    }
                    //var client = new System.Net.Http.HttpClient();
                    //// var response = await client.GetAsync(new Uri("http://172.31.0.77/XamarinAzure/tables/SkuMaster?ZUMO-API-VERSION=2.0.0&SkuCode=" + txtSkuCode.Text));
                    //var response = await client.GetAsync(new Uri("http://xamarinprojazureapi.azurewebsites.net/tables/SkuMaster?ZUMO-API-VERSION=2.0.0&SkuCode=" + txtSkuCode.Text));



                    //if (response.IsSuccessStatusCode)
                    //{
                    //    var result1 = JsonConvert.DeserializeObject<List<SkuMaster>>(response.Content.ReadAsStringAsync().Result);
                    //    if (result1.Count == 1)
                    //    {
                    //        DisplayAlert("Alert", "SkuCode already exists " + txtSkuCode.Text, "Ok");
                    //        return;
                    //    }
                    //}
                    //else
                    //{
                    //    DisplayAlert("Alert", "ServerStatus Code :" + response.IsSuccessStatusCode.ToString(), "Ok");
                    //    return;
                    //}
                    HgCv.IsVisible = false;
                    SkuMaster sm = new SkuMaster();
                    //sm.Id = skuidvalue;
                   // sm.Id ="006CBCE7-D4DF-48B4-9271-77E94F35E879";
                    
                    sm.MerchantId = "M001";
                    sm.SkuCode = txtSkuCode.Text;
                    sm.SKUShortName = txtBillDescription.Text;
                    sm.SKULongName = txtProductDescription.Text;
                    sm.GroupCode = 1;
                    if (BusinessLogicViewModel.EnableBrand == "1")
                    {
                        sm.HG_Code = 0;
                    }
                    else
                    {
                        sm.HG_Code = 0;
                    }
                    if (BusinessLogicViewModel.EnableBrand == "1")
                    {
                        sm.BrandCode = BusinessLogicViewModel.GetCode("Select BrandCode from Brand Where BrandDesc='" + txtBrand.Text + "'");
                    }
                    else
                    {
                        sm.BrandCode = 0;
                    }
                    sm.MfgCode = 1;
                    if (BusinessLogicViewModel.EnableTax == "1")
                    {
                        sm.TaxGrpCode = "";// BusinessLogicViewModel.GetCode("Select TaxGrpCode from TaxFile Where TaxGrpName='" + Convert.ToInt32(txtBrand.Text) + "'");//"TG1";
                    }
                    else
                    {
                        sm.TaxGrpCode = "";
                    }
                    sm.UnitCode = 1;
                    if (swOpenRate.IsToggled == true)
                        sm.OpenRate = true;
                    else
                        sm.OpenRate = false;
                    sm.Kit = false;
                    sm.Discountable = false;
                    sm.ConsiderBulk = false;
                    if (swMaintainInventory.IsToggled == true)
                        sm.NonInv = true;
                    else
                        sm.NonInv = false;
                    sm.SkuType = "NF";
                    sm.CaseQty = 0;
                    sm.InnerCaseQty = 0;
                    sm.Qoh = Convert.ToDouble(txtQOH.Text);
                    sm.EanNumber = false;
                    if (swAllowOnlyDecimal.IsToggled == true)
                        sm.AllowDecimal = true;
                    else
                        sm.AllowDecimal = false;
                    sm.HSNCode = ""; //BusinessLogicViewModel.GetCode("Select HG_Code as MaxCode from Hierarchy_1 Where ");
                    sm.ChangeBy = "Admin";
                    sm.CreatedBy = "Admin";
                    sm.LastUpdated = DateTime.Now;
                    sm.CreatedDate = DateTime.Now;
                    PluMasterPrices pluMasterPrices = new PluMasterPrices();
                   pluMasterPrices.Id = BusinessLogicViewModel.PluIdvalue;
                   // pluMasterPrices.Id = "5A758561-CDB4-48BA-B022-416439FA685F";
                    pluMasterPrices.MerchantId = "M001";
                    pluMasterPrices.SkuCode = txtSkuCode.Text;
                    pluMasterPrices.PluCode = txtEan.Text;
                    pluMasterPrices.PluPriceCode = "";
                    pluMasterPrices.Priority = 0;
                    pluMasterPrices.DealerSP = 0;
                    pluMasterPrices.MRP = Convert.ToDouble(txtMRP.Text);
                    pluMasterPrices.SalePrice = Convert.ToDouble(txtsales.Text);
                    pluMasterPrices.PluCode = txtEan.Text;
                    pluMasterPrices.LastUpDated = DateTime.Now;
                    pluMasterPrices.Inactive = false;
                    BusinessLogicViewModel.UpdateTaskAsync(sm, pluMasterPrices);
                    btnSaveProduct.IsEnabled = true;
                    //update data to table
                   Int64 VendorCodeExists = BusinessLogicViewModel.GetCode("Select VendorCode from VendorMaster  Where VendorName='" + txtVendor.Text + "'");
                    if (VendorCodeExists == 0)
                    {
                        Int64 VendorCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(VendorCode as int)),0) as VendorCode from VendorMaster");
                        VendorCode++;
                        BusinessLogicViewModel.InsertAddVendor(VendorCode, txtVendor.Text);
                    }
                    Int64 UOMCodeExists = BusinessLogicViewModel.GetCode("Select UnitCode from UOMeasurement  Where UOM='" + entryUom.Text + "'");
                    if (UOMCodeExists == 0)
                    {
                        Int64 UOMCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(UnitCode as int)),0) as UnitCode from UOMeasurement");
                        UOMCode++;
                        BusinessLogicViewModel.InsertAddUOM(UOMCode, entryUom.Text);
                    }
                    Int64 BrandCodeExists = BusinessLogicViewModel.GetCode("Select BrandCode from Brand  Where BrandDesc='" + txtBrand.Text + "'");
                    if (BrandCodeExists == 0)
                    {
                        Int64 BrandCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(BrandCode as int)),0) as BrandCode from Brand");
                        BrandCode++;
                        BusinessLogicViewModel.InsertAddBrand(BrandCode, txtBrand.Text);
                        txtBrand.Text = AddnewtxtBrand.Text;
                        AddnewtxtBrand.Text = "";

                    }
                    Int64 TaxGrpCodeExists = BusinessLogicViewModel.GetCode("Select TaxGrpCode from TaxFile  Where TaxGrpDesc='" + entryTax.Text + "'");
                    if (TaxGrpCodeExists == 0)
                    {
                        Int64 TaxCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(TaxGrpCode as int)),0) as TaxGrpCode from TaxFile");
                        TaxCode++;
                        BusinessLogicViewModel.InsertAddTax(TaxCode, entryTax.Text);
                        entryTax.Text = AddnewtxtTax.Text;
                        AddnewtxtTax.Text = "";

                    }

                  // await BusinessLogicViewModel.PushLocalData();
                   //ClearFields();
                    //if (BusinessLogicViewModel.EnableAutoSkucode == "1")
                    //{
                    //    GetAutoSkuCode();
                    //}

                    //ss

                }
            }
            catch (Exception ee)
            {
                btnSaveProduct.IsEnabled = true;
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        public async void GetAutoSkuCode()
        {
            txtSkuCode.IsEnabled = false;
            var client = new System.Net.Http.HttpClient();
            var jsonRequest = new LoginRequest { username = BusinessLogicViewModel.user, password = BusinessLogicViewModel.password, merchantid = "E1001" };

            var serializedJsonRequest = JsonConvert.SerializeObject(jsonRequest);
            HttpContent content = new StringContent(serializedJsonRequest, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(new Uri("http://xamarinprojazureapi.azurewebsites.net/api/login?ZUMO-API-VERSION=2.0.0"), content);
            // var response = await client.PostAsync(new Uri("http://172.31.0.77/XamarinAzure/api/login?ZUMO-API-VERSION=2.0.0"), content);

            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result);
                result1 = JsonConvert.DeserializeObject<LoginSuccessResponse>(result);
                BusinessLogicViewModel.EnableAutoSkucode = result1.EnableAutoSkucode.ToString();
                BusinessLogicViewModel.LastSkucode = result1.LastSkucode;
                txtSkuCode.Text = Convert.ToInt32(BusinessLogicViewModel.LastSkucode + 1).ToString();
            }
        }
        public void ClearFields()
        {
            txtSkuCode.Text = "";
            txtBillDescription.Text = "";
            txtProductDescription.Text = "";
            txtHierarchyLevel.Text = "";
            txtCostPrice.Text = "";
            txtMBQ.Text = "";
            txtQOH.Text = "";
            txtMRP.Text = "";
            txtBrand.Text = "";
            txtVendor.Text = "";
            txtsales.Text = "";
            txtHSNCode.Text = "";
            entryUom.Text = "";
            entryTax.Text = "";
            swAllowOnlyDecimal.IsToggled = false;
            swAllowOnlyScan.IsToggled = false;
            swOpenRate.IsToggled = false;
            swMaintainInventory.IsToggled = false;
            swInActive.IsToggled = false;
            txtMarkUpDown.Text = "";
            txtEan.Text = "";
        }

        public void ImgBrandclick(Object o, EventArgs e)
        {
            BrandCv.IsVisible = true;
        }
        public void CloseBrandlist(Object o, EventArgs e)
        {
            BrandCv.IsVisible = false;
        }
        public void ImgVendorclick(Object o, EventArgs e)
        {
            vendorCv.IsVisible = true;
        }
        public void CloseVendorlist(Object o, EventArgs e)
        {
            vendorCv.IsVisible = false;
        }
        public void ImgUomclick(Object o, EventArgs e)
        {
            UomCv.IsVisible = true;
        }
        public void CloseUomlist(Object o, EventArgs e)
        {
            UomCv.IsVisible = false;
        }
        public void ImgTaxclick(Object o, EventArgs e)
        {
            TaxCv.IsVisible = true;
        }
        public void CloseTaxlist(Object o, EventArgs e)
        {
            TaxCv.IsVisible = false;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            txtH1.Text = "";
            txtH2.Text = "";
            Hgpop.IsVisible = false;
        }
        private void CostPrice_Focused(object sender, FocusEventArgs e)
        {
            // txtCostPrice.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtCostPrice);
        }
        private void MarkUpDown_Focused(object sender, FocusEventArgs e)
        {
            //txtMarkUpDown.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtMarkUpDown);
        }
        private void QOH_Focused(object sender, FocusEventArgs e)
        {
            try
            {
                txtQOH.Text = BusinessLogicViewModel.ConvertThreeDecimal(txtQOH);
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void MBQ_Focused(object sender, FocusEventArgs e)
        {
            //txtMBQ.Text = BusinessLogicViewModel.ConvertThreeDecimal(txtMBQ);
        }
        private void btnSavePopupProduct(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtH1.Text == "")
            //    {
            //        DisplayAlert("Alert", "Please enter or select the H1Group", "Ok");
            //    }
            //    else if (txtH2.Text == "")
            //    {
            //        DisplayAlert("Alert", "Please enter or select the H2Group", "Ok");
            //    }
            //    else
            //    {
            //        txtHierarchyLevel.Text = txtH1.Text + "," + txtH2.Text;
            //        Hgpop.IsVisible = false;
            //    }
            //}
            //catch (Exception ee)
            //{
            //    DisplayAlert("Alert", ee.Message, "Ok");
            //}
            try
            {
                Int64 H1Exists = BusinessLogicViewModel.GetCode("Select H1_Code from Hierarchy_1 Where Description='" + txtH1.Text + "'");
                Int64 H1Code = 0, H2Code = 0;
                if (H1Exists == 0)
                {
                    H1Code = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(H1_Code as int)),0) as H1_Code from Hierarchy_1");
                    H1Code++;
                    BusinessLogicViewModel.InsertAddH1(H1Code, txtH1.Text);
                }
                Int64 H2Exists = BusinessLogicViewModel.GetCode("Select H2_Code from Hierarchy_2 Where Description='" + txtH2.Text + "'");
                if (H2Exists == 0)
                {
                    H2Code = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(H2_Code as int)),0) as H2_Code from Hierarchy_2");
                    H2Code++;
                    BusinessLogicViewModel.InsertAddH2(H2Code, txtH2.Text);
                }
                Int64 HGExists = BusinessLogicViewModel.GetCode("Select HG_Code from HierarchyGroup where H1_Code='" + H1Code + "' and H2_Code='" + H2Code + "'");
                if (HGExists == 0)
                {
                    Int64 HGCode = BusinessLogicViewModel.GetCode("Select IfNull(Max(cast(HG_Code as int)),0) as HG_Code from HierarchyGroup");
                    HGCode++;
                    BusinessLogicViewModel.InsertAddHG(HGCode, H1Code, H2Code);
                }
                txtHierarchyLevel.Text = txtH1.Text + "," + txtH2.Text;
                txtH1.Text = "";
                txtH2.Text = "";
                HgCv.IsVisible = false;
                Hgpop.IsVisible = false;
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void txtCostPrice_Completed(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtCostPrice.Text))
                {
                    DisplayAlert("Error", "Enter Cost Price", "Ok");
                    return;
                }
                else
                {
                    txtCostPrice.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtCostPrice);
                }
                if (!String.IsNullOrEmpty(txtsales.Text))
                {
                    if (!(double.Parse(txtCostPrice.Text) < double.Parse(txtsales.Text)))
                    {
                        DisplayAlert("Hey!", "Sales Price Cannot be Less than Cost Price", "Ok");
                    }
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void txtMarkUpDown_Completed(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCostPrice.Text)) { }

                if (BusinessLogicViewModel.EnableMarkUp == "0")
                {
                    if (String.IsNullOrEmpty(txtMarkUpDown.Text))
                    {
                        DisplayAlert("Error", "Enter MarkDown", "Ok");
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtMRP.Text) && !(txtMRP.Text == "0"))
                        {
                            int disc = Convert.ToInt32(txtMarkUpDown.Text);

                            double discount = Convert.ToDouble((disc / 100.0));
                            //txtCostPrice.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtCostPrice);
                            double costpric = double.Parse(txtMRP.Text) - (double.Parse(txtMRP.Text) * discount);

                            txtsales.Text = Convert.ToString(costpric);
                        }
                        else
                        {
                            DisplayAlert("Error", "Please Enter the MRP", "Ok");
                        }
                    }
                }
                else
                {
                    if (String.IsNullOrEmpty(txtMarkUpDown.Text))
                    {
                        DisplayAlert("Error", "Enter MarkUp", "Ok");
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(txtCostPrice.Text) && !(txtCostPrice.Text == "0"))
                        {
                            int disc = Convert.ToInt32(txtMarkUpDown.Text);

                            double discount = Convert.ToDouble((disc / 100.0));
                            //txtCostPrice.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtCostPrice);
                            double costpric = double.Parse(txtCostPrice.Text) + (double.Parse(txtCostPrice.Text) * discount);

                            txtsales.Text = Convert.ToString(costpric);
                        }
                        else
                        {
                            DisplayAlert("Error", "Please Enter the Cost Price", "Ok");
                        }
                    }

                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void txtSalerice_Completed(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtsales.Text))
                {
                    DisplayAlert("Error", "Cannot Blank", "Ok");
                }
                else
                {
                    txtMRP.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtMRP);
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

        private void txtMrp_Completed(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtMRP.Text))
                {
                    DisplayAlert("Error", "Enter MRP", "Ok");
                    return;
                }
                else
                {
                    txtMRP.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtMRP);
                }
                if (!String.IsNullOrEmpty(txtMRP.Text))
                {
                    if (!(double.Parse(txtCostPrice.Text) <= double.Parse(txtMRP.Text)))
                    {
                        DisplayAlert("Error", "MRP Cannot be Less Than Cost Price", "Ok");
                    }
                }
                //else
                //{
                //    txtMRP.Text = BusinessLogicViewModel.ConvertTwoDecimal(txtMRP);
                //}
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void txtQOH_Completed(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtQOH.Text))
                {
                    DisplayAlert("Error", "Enter Qoh", "Ok");
                }
                else
                {
                    txtQOH.Text = BusinessLogicViewModel.ConvertThreeDecimal(txtQOH);
                }
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        private void txtMBQ_Completed(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(txtMBQ.Text))
                {
                    DisplayAlert("Error", "Enter MBQ", "Ok");
                }
                //else
                //{
                //    txtMBQ.Text = BusinessLogicViewModel.ConvertThreeDecimal(txtMBQ);
                //}
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }
        int StrQoh = 0;

        private async void Cameraclick(object sender, EventArgs e)
        {

            var action = await DisplayActionSheet("Choose Any One", "Cancel", null, "Camera", "Gallery");
         switch (action)
         {
             case "Camera":
                 camera();
                 break;
             case "Gallery":
                 gallery();
                 break;
             default:
                 break;
         }

      


        }

        public void QtyMinusclick(Object o, EventArgs e)
        {
            try
            {
                if (!(StrQoh == 0))
                {
                    StrQoh = int.Parse(txtQOH.Text);
                    StrQoh = StrQoh - 1;
                    txtQOH.Text = "" + StrQoh;
                }

                else
                {
                    DisplayAlert("", "Already Qty=0", "Ok");
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
        public void QtyPlusclick(Object o, EventArgs e)
        {
            try
            {
                StrQoh = int.Parse(txtQOH.Text);
                StrQoh = StrQoh + 1;
                txtQOH.Text = "" + (StrQoh);
            }
            catch (Exception ee)
            {
                DisplayAlert("Alert", ee.Message, "Ok");
            }
        }

    }
}

