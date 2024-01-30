using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectsLayer;

namespace ILogicLayer
{
    public interface IClientManager
    {
        public int add(Client client);
        public int buyBike(Bike bike, Client client);
        public List<Client> getAllClients();
        public int update(Client client);
    }
}
