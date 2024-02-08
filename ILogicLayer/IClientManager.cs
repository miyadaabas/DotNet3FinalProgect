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
        int add(Client client);
        int buyBike(Bike bike, Client client);
        List<Client> getAllClients();
        int update(Client client);
    }
}
