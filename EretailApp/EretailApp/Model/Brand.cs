using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
    public class Brand
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long BrandCode { get; set; }
        public string BrandDesc { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return BrandCode.ToString(); } }
    }
}
