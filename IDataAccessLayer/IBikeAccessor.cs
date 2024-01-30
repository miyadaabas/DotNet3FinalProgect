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
        public int insertBike(Bike bike);
        public List<Bike> selectAllBikes();
        public int update(Bike bike);
    }
}
