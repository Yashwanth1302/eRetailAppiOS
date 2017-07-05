namespace EretailApp.Model
{
    public class TaxFile
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public string TaxGrpCode { get; set; }
        public string TaxGrpDesc { get; set; }
        public bool Inactive { get; set; }
        [Microsoft.WindowsAzure.MobileServices.Version]
        public string AzureVersion { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string DateDisplay { get { return TaxGrpCode.ToString(); } }
    }
}
