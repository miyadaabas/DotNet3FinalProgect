using System;
using System.Collections.Generic;
// using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer
{
    public class Client
    {
        public int client_id {  get; set; }
        public string client_first_name { get; set; }
        public string client_last_name { get; set; }
        public string email { get; set; }
        public string phone_number { get; set; }
        public string line1 { get; set; }
        public string line2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string county { get; set; }
        public string zipcode { get; set; }
        public string country { get; set; }
        public string routing_number { get; set; }
        public string account_number { get; set; }
        public string bank_name { get; set; }
    }
}
