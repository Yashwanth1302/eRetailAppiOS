using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
    public class Hierarchy_1
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long H1_Code { get; set; }
        public string Description { get; set; }


        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return H1_Code.ToString(); } }
    }
}
