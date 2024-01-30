using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectsLayer;

namespace ILogicLayer
{
    public interface IBikeManager
    {
        public int addBike(Bike bike);
        public int edit(Bike bike);
        public List<Bike> getAllBikes();
    }
}
