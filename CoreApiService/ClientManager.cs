using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Crud.Client;
using POJOS;

namespace CoreApiService
{
    public class ClientManager : BaseManager
    {
        private ClientCrudFactory clientCrudFactory;

        public ClientManager()
        {
            clientCrudFactory = new ClientCrudFactory();
        }

        public void Create(ClientType client)
        {
            clientCrudFactory.Create(client);
        }

        public List<ClientType> RetrieveAll()
        {
            return clientCrudFactory.RetrieveAll<ClientType>();
        }

        public ClientType RetrieveById(ClientType client)
        {
               return clientCrudFactory.Retrieve<ClientType>(client);
        }

        public void Update(ClientType client)
        {
            clientCrudFactory.Update(client);
        }

        public void Delete(ClientType client)
        {
            clientCrudFactory.Delete(client);
        }
    }
}
