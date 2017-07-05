using Newtonsoft.Json;
using EretailApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
    public class PluMasterPrices
    {
        string id;
        //public string Id { get; set; }
        public string MerchantId { get; set; }
        public string SkuCode { get; set; }
        public string PluCode { get; set; }
        public string PluPriceCode { get; set; }
        public double MRP { get; set; }
        public double SalePrice { get; set; }
        public double DealerSP { get; set; }
        public int Priority { get; set; }
        public DateTime LastUpDated { get; set; }
        public bool Inactive { get; set; }
        //[Microsoft.WindowsAzure.MobileServices.Deleted]
        //public bool Deleted { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }
        [JsonProperty(PropertyName = "id")]
        public string Id
        {
            get
            {
                BusinessLogicViewModel.PluIdvalue = id;
                return id;
            }
            set
            {
                BusinessLogicViewModel.PluIdvalue = id;
                id = value;
            }
        }

        //[Microsoft.WindowsAzure.MobileServices.UpdatedAt]
        //public string UpdatedAt { get; set; }
        //[Microsoft.WindowsAzure.MobileServices.CreatedAt]
        //public string CreatedAt { get; set; }
        //[Newtonsoft.Json.JsonIgnore]
        //public string DateDisplay { get { return SkuCode.ToString(); } }
    }
}
