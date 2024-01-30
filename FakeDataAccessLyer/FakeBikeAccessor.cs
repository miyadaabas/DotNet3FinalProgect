using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjectsLayer;

namespace FakeDataAccessLayer
{
    public class FakeBikeAccessor : IBikeAccessor
    {
        private List<Bike> bikes;
        public FakeBikeAccessor()
        {
            this.bikes = bikes = new List<Bike>();
        }
        public FakeBikeAccessor(List<Bike> bikes)
        {
            this.bikes = bikes;
        }
        public int insertBike(Bike bike)
        {
            int result = bikes.Count;
            bikes.Add(bike);
            return bikes.Count - result;    
        }

        public List<Bike> selectAllBikes()
        {
            return bikes;
        }

        public int update(Bike bike)
        {
            int result = 0;
            foreach (Bike item in bikes)
            {
                if (item.ID == bike.ID)
                {
                    item.Name = bike.Name;
                    item.Type = bike.Type;
                    item.Price = bike.Price;
                    item.Quality = bike.Quality;
                    item.Model = bike.Model;
                    item.Total = bike.Total;
                    result = 1;
                    break;
                }
            }
            return result;
        }
    }
}
