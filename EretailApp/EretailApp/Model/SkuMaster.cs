using EretailApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
    public class SkuMaster
    {
        string id;

        //  public string Id { get; set; }
        public string MerchantId { get; set; }
        public string SkuCode { get; set; }
        public string SKULongName { get; set; }
        public string SKUShortName { get; set; }
        public long GroupCode { get; set; }
        public long HG_Code { get; set; }
        public long BrandCode { get; set; }
        public long MfgCode { get; set; }
        public long SupplierCode { get; set; }
        public string TaxGrpCode { get; set; }
        public long UnitCode { get; set; }
        public Boolean OpenRate { get; set; }
        public Boolean Kit { get; set; }
        public Boolean Discountable { get; set; }
        public Boolean ConsiderBulk { get; set; }
        public Boolean NonInv { get; set; }
        public string SkuType { get; set; }
        public Single CaseQty { get; set; }
        public Single InnerCaseQty { get; set; }
        public double Qoh { get; set; }
        public Boolean EanNumber { get; set; }
        public Boolean AllowDecimal { get; set; }
        public string HSNCode { get; set; }
        public DateTime LastUpdated { get; set; }
        public string ChangeBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        //[Microsoft.WindowsAzure.MobileServices.Deleted]
        //public bool Deleted { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        //{
        //    get
        //    {
               
        //        return id;
        //    }
        //    set
        //    {
        //        id = value;
        //    }
        //}


        //[Microsoft.WindowsAzure.MobileServices.UpdatedAt]
        //public string UpdatedAt { get; set; }
        //[Microsoft.WindowsAzure.MobileServices.CreatedAt]
        //public string CreatedAt { get; set; }
        //[Newtonsoft.Json.JsonIgnore]
        //public string DateDisplay { get { return SkuCode.ToString(); } }

        //[Newtonsoft.Json.JsonIgnore]
        //public string TimeDisplay { get { return DateUtc.ToLocalTime().ToString("t") + " " + OS.ToString(); } }

        //[Newtonsoft.Json.JsonIgnore]
        //public string SkuCodeDisplay { get { return SkuCode.ToString(); } }

        //[Newtonsoft.Json.JsonIgnore]
        //public string SkuLongNameDisplay { get { return SkuLongName.ToString(); } }
        //[Newtonsoft.Json.JsonIgnore]
        //public string SkuShortNameDisplay { get { return SkuShortName.ToString(); } }
        //[Newtonsoft.Json.JsonIgnore]
        //public string GroupCodeDisplay { get { return GroupCode.ToString(); } }
        //[Newtonsoft.Json.JsonIgnore]
        //public string SkuLevelCodeDisplay { get { return SkuLevelCode.ToString(); } }
        //[Newtonsoft.Json.JsonIgnore]

        //public string UOMCodeDisplay { get { return UOMCode.ToString(); } }
        //[Newtonsoft.Json.JsonIgnore]
        //public string BrandCodeDisplay { get { return BrandCode.ToString(); } }
        //[Newtonsoft.Json.JsonIgnore]
        //public string TaxCodeDisplay { get { return TaxCode.ToString(); } }

        //[Newtonsoft.Json.JsonIgnore]
        //public string VendorCodeDisplay { get { return VendorCode.ToString(); } }
    }

    public class ProductLevelDescription
    {
        public string Description
        {
            get; set;

        }


    }
}