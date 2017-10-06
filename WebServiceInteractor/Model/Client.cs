using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceInteractor.Model
{
    using WS_NS_Client = SKGeliosWebService.WS_NS_Client;

    public class Client
    {
        private IClientListener listener;
        private WS_NS_Client client;

        public Client(IClientListener listener)
        {
            this.listener = listener;
        }

        public WS_NS_Client Init(int id, bool idSpecified, String firstName, String lastName, DateTime birthDate, bool birthDateSpecified, String docNumber)
        {
            return client = new WS_NS_Client
            {
                Id = id,
                IdSpecified = idSpecified,
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
                BirthDateSpecified = birthDateSpecified,
                Doc_Number = docNumber
            };
        }

        public WS_NS_Client Init(String firstName, String lastName, DateTime birthDate, int id = 0, String docNumber = "")
        {
            return Init(id, true, firstName, lastName, birthDate, true, docNumber);
        }

        public WS_NS_Client WsNsClient
        {
            get { return client; }
            set { client = value; }
        }
    }
}