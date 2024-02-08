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
        int buyBike(Bike bike, Client client);
        int Insert(Client client);
        List<Client> selectAllClients();
        int UpdateClient(Client client);
    }
}
