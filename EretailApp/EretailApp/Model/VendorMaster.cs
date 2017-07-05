using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
    public class VendorMaster
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long VendorCode { get; set; }
        public string VendorName { get; set; }
        public decimal DiscPer { get; set; }
        public int CreditDays { get; set; }
        public string FGL { get; set; }
        public string DrugLic { get; set; }
        public int LeadDays { get; set; }
        public string LeadTime { get; set; }
        public Boolean Inactive { get; set; }
        public string LastUpdated { get; set; }
        public string ChangeBy { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return VendorCode.ToString(); } }
    }
}
