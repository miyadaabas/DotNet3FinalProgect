using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjectsLayer;

namespace IDataAccessLayer
{
    public interface IClientAccessor
    {
        public int buyBike(Bike bike, Client client);
        public int Insert(Client client);
        public List<Client> selectAllClients();
        public int UpdateClient(Client client);
    }
}
