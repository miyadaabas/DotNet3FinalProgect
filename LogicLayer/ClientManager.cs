using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IDataAccessLayer;
using ILogicLayer;
using DataAccessLayer;
using DataObjectsLayer;

namespace LogicLayer
{
    public class ClientManager : IClientManager
    {
        private IClientAccessor _clientAccessor;

        public ClientManager() {
            _clientAccessor = new ClientAccessor();
        }

        public ClientManager(IClientAccessor clientAccessor)
        {
            _clientAccessor = clientAccessor;
        }

        public int add(Client client)
        {
            int result = 0;
            result = _clientAccessor.Insert(client);
            return result;
        }

        public int buyBike(Bike bike, Client client)
        {
            int result = 0;
            result = _clientAccessor.buyBike(bike,client);
            return result;
        }

        public List<Client> getAllClients()
        {
            List<Client> clients = new List<Client>();
            clients = _clientAccessor.selectAllClients();
            return clients;
        }

        public int update(Client client)
        {
            int result = 0;
            result = _clientAccessor.UpdateClient(client);
            return result;
        }
    }
}
