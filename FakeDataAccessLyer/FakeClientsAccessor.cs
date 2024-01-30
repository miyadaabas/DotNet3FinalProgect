using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using DataObjectsLayer;
namespace FakeDataAccessLayer
{
    public class FakeClientsAccessor : IClientAccessor
    {
        private List<Client> clients;
        private List<BuyBike> buyBikeList;

        public FakeClientsAccessor()
        {
            clients = new List<Client>();
            buyBikeList = new List<BuyBike>();
        }

        public FakeClientsAccessor(List<Client> clients, List<BuyBike> buyBikeList)
        {
            this.clients = clients;
            this.buyBikeList = buyBikeList;
        }

        public int buyBike(Bike bike, Client client)
        {
            int result = buyBikeList.Count;
           BuyBike buyBike = new BuyBike();
            buyBike.BikeID = bike.ID;
            buyBike.clientId = client.client_id;
            buyBike.Price = bike.Price;
            buyBikeList.Add(buyBike);
            return buyBikeList.Count - result;
        }

        public int Insert(Client client)
        {
            int result = clients.Count;
            clients.Add(client);
            return clients.Count - result;
        }

        public List<Client> selectAllClients()
        {
            return clients;
        }

        public int UpdateClient(Client client)
        {
            int result = 0;
            foreach (Client item in clients)
            {
                if (item.client_id == client.client_id)
                {
                    item.client_first_name = client.client_first_name;
                   item.client_last_name = client.client_last_name;
                    item.email = client.email;
                    item.phone_number = client.phone_number ;
                    item.line1 = client.line1 ;
                    item.line2 = client.line2 ;
                    item.city = client.city ;
                    item.state = client.state;
                    item.county = client.county;
                    item.zipcode = client.zipcode;
                    item.country = client.country;
                    item.routing_number = client.routing_number;
                    item.account_number = client.account_number;
                    item.bank_name = client.bank_name;
                    result = 1;
                    break;
                }
            }
            return result;
        }
    }
}
