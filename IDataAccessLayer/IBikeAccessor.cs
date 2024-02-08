using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectsLayer;

namespace IDataAccessLayer
{
    public interface IBikeAccessor
    {
        int insertBike(Bike bike);
        List<Bike> selectAllBikes();
        int update(Bike bike);
    }
}
