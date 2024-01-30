using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ILogicLayer;
using DataAccessLayer;
using IDataAccessLayer;
using DataObjectsLayer;

namespace LogicLayer
{
    public class BikeManager : IBikeManager
    {
        private IBikeAccessor bikeAccessor;
        public BikeManager()
        {
            this.bikeAccessor = new BikeAccessor();
        }
        public BikeManager(IBikeAccessor bikeAccessor)
        {
            this.bikeAccessor = bikeAccessor;
        }

        public int addBike(Bike bike)
        {
            int result = 0;
            result = bikeAccessor.insertBike(bike);
            return result;
        }

        public int edit(Bike bike)
        {
            int result = 0;
            result = bikeAccessor.update(bike);
            return result;
        }

        public List<Bike> getAllBikes()
        {
            List<Bike> bikes = new List<Bike>();
            bikes = bikeAccessor.selectAllBikes();
            return bikes;
        }
    }
}
