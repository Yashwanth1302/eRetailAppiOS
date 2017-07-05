using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
    public class Hierarchy_2
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long H2_Code { get; set; }
        public string Description { get; set; }


        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return H2_Code.ToString(); } }
    }
}
