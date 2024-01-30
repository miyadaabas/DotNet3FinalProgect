using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectsLayer
{
    public class BuyBike
    {
        public int clientId {  get; set; }  
        public int BikeID { get; set; }
        public string? Price { get; set; }
    }
}
