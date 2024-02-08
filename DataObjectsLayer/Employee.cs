using System;
using System.Collections.Generic;
// using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer
{
    public class Employee
    {
        public int Employee_id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SSN { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string County { get; set; }
        public string Zipcode { get; set; }
        public string Role_id { get; set; }
        public string AccountNumber { get; set; }
        public string RoutinNumber { get; set; }
        public string bankName { get; set; }
        public string salaryType { get; set; }
        public string salaryAmount { get; set; }
        public string email { get; set; }
        public string passwordHash { get; set; }
    }
}
