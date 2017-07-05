using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
    public class HierarchyGroup
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long HG_Code { get; set; }
        public long H1_Code { get; set; }
        public long H2_Code { get; set; }
        public long H3_Code { get; set; }
        public long H4_Code { get; set; }
        public long H5_Code { get; set; }
      



        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return HG_Code.ToString(); } }
    }



    public class HierarchyGroupDescription
    {
        public string Description { get; set; }
    }
}
