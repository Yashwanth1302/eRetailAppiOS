using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EretailApp.Model
{
   public class EmployeeMaster
    {
        public string Id { get; set; }
        public string MerchantId { get; set; }
        public long Emp_Code { get; set; }
        public string CardNo { get; set; }
        public string Emp_SurName { get; set; }
        public string Emp_Name { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
        public string MobileNumber { get; set; }
        public string ContactNo2 { get; set; }
        public string ContactNo3 { get; set; }
        public string ContactNo4 { get; set; }
        public string Email { get; set; }
        public DateTime CardActivateOn { get; set; }
        public Boolean EmpActivate { get; set; }

    }
}