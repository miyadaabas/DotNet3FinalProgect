using LogicLayer;
using ILogicLayer;
using IDataAccessLayer;
using DataObjectsLayer;
using FakeDataAccessLayer;
using System.Text;
using System.Security.Cryptography;

namespace LogicLayerTests
{
    public class ClientManagerTests
    {
        private IClientAccessor _clientAccessor;
        private IClientManager _clientManager;
        private List<Client> clients;
        private List<BuyBike> buyBikeList;
        private List<Bike> bikes;

        [SetUp]
        public void Setup()
        {
            clients = new List<Client>();
            clients.Add(generateClient(1, "test1"));
            clients.Add(generateClient(2, "test2"));
            clients.Add(generateClient(3, "test3"));
            clients.Add(generateClient(4, "test4"));
            clients.Add(generateClient(5, "test5"));
            clients.Add(generateClient(6, "test6"));
            clients.Add(generateClient(7, "test7"));
            clients.Add(generateClient(8, "test8"));
            clients.Add(generateClient(9, "test9"));
            clients.Add(generateClient(10, "test10"));
            buyBikeList = new List<BuyBike>();
            buyBikeList.Add(generateBuyBike(1, 1, "100"));
            buyBikeList.Add(generateBuyBike(2, 2, "200"));
            buyBikeList.Add(generateBuyBike(3, 3, "300"));
            bikes = new List<Bike>();
            bikes.Add(new Bike()
            {
                ID = 1,
                Name = "test1",
                Model = "model1",
                Price = "100",
                Quality = "100",
                Total = 100,
                Type = "type1"
            }
            );
            bikes.Add(new Bike() 
            { 
                ID = 2,
                Name = "test2",
                Type = "type2",
                Price = "200",
                Quality = "200",
                Model = "model2",
                Total = 200
            }
            );
            _clientAccessor = new FakeClientsAccessor(clients, buyBikeList);
            _clientManager = new ClientManager(_clientAccessor);
        }

        private BuyBike generateBuyBike(int clientId, int bikeID, string Price)
        {
            BuyBike buyBike = new BuyBike();
            buyBike.clientId = clientId;
            buyBike.BikeID = bikeID;
            buyBike.Price = Price;
            return buyBike;
        }

        private Client generateClient(int id,string value)
        {
            Client client = new Client();
            client.client_id = id;
            client.client_first_name = value;
            client.client_last_name = value;
            client.email = value;
            client.phone_number = value;
            client.line1= value;
            client.line2= value;
            client.city = value;
            client.state = value;
            client.county = value;
            client.zipcode = value;
            client.country = value;
            client.routing_number = value;
            client.account_number = value;
            client.bank_name = value;
            return client;
        }
       
        [Test]
        public void TestAddClient()
        {
           Client client = new Client();
            client = generateClient(100, "teat100");
            int expected = 1;
            int actual = _clientManager.add(client);
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void TestBuyBike()
        {
            int expected = 1;
            int actual = _clientManager.buyBike(bikes[0], clients[0]);
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void TestGetAllClients()
        {
            int expected = 10;
            int actual = _clientManager.getAllClients().Count;
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void TestUpdateClient()
        {
            clients[0].client_first_name = "Test";
            int expected = 1;
            int actual = _clientManager.update(clients[0]);
            Assert.That(expected, Is.EqualTo(actual));
        }
    }
}