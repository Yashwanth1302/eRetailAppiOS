
namespace EretailApp.Model
{
    public class UOMeasurement                 
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long UnitCode { get; set; }
        public string UOM { get; set; }

        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return UnitCode.ToString(); } }
    }
}
