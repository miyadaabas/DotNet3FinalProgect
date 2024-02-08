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
        int addBike(Bike bike);
        int edit(Bike bike);
        List<Bike> getAllBikes();
    }
}
