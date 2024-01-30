using LogicLayer;
using ILogicLayer;
using IDataAccessLayer;
using DataObjectsLayer;
using FakeDataAccessLayer;
using System.Text;
using System.Security.Cryptography;
using DataAccessLayer;
using Newtonsoft.Json.Linq;

namespace LogicLayerTests
{
    public class BikeManagerTests
    {
        private IBikeAccessor bikeAccessor;
        private IBikeManager bikeManager;
        private List<Bike> bikes;

        [SetUp]
        public void Setup()
        {
           bikes = new List<Bike>();
           bikes.Add(generateBike(1, "test1"));
           bikes.Add(generateBike(2, "test2"));
           bikes.Add(generateBike(3, "test3"));
           bikes.Add(generateBike(4, "test4"));
           bikes.Add(generateBike(5, "test5"));
           bikes.Add(generateBike(6, "test6"));
           bikes.Add(generateBike(7, "test7"));
           bikes.Add(generateBike(8, "test8"));
           bikes.Add(generateBike(9, "test9"));
           bikes.Add(generateBike(10, "test10"));
           bikeAccessor = new FakeBikeAccessor(bikes);
           bikeManager = new BikeManager(bikeAccessor);
        }

        private Bike generateBike(int id,string value)
        {
            Bike bike = new Bike();
            bike.ID = id;
            bike.Name = value;
            bike.Type = value;
            bike.Price = value;
            bike.Model = value;
            bike.Total = id;
            return bike;
        }
        [Test]
        public void TestAddBike()
        {
            Bike bike = generateBike(11,"test");
            int expected = 1;
            int actual = bikeManager.addBike(bike);
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void TestEditBike()
        {
            bikes[0].Price = "300";
            int expected = 1;
            int actual = bikeManager.edit(bikes[0]);
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void TestGetAllBikes()
        {
            int expected = 10;
            int actual = bikeManager.getAllBikes().Count;
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}