using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
   public class VendorAddresse
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long VendorCode { get; set; }
        public string Contact { get; set; }
        public string Area { get; set; }
        public string Town { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Phones { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Zip { get; set; }
        public string URL { get; set; }

    }
}