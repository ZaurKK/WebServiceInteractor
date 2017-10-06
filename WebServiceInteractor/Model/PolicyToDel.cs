using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceInteractor.Model
{
    using WS_NS_Policy_To_Del = SKGeliosWebService.WS_NS_PolicyTo_Del;

    public class PolicyToDel
    {
        private IPolicyToDelListener listener;
        private WS_NS_Policy_To_Del policyToDel;

        public PolicyToDel(IPolicyToDelListener listener)
        {
            this.listener = listener;
        }

        public WS_NS_Policy_To_Del Init(String id, DateTime deletedDate, bool deletedDateSpecified = true)
        {
            return policyToDel = new WS_NS_Policy_To_Del
            {
                Id = id,
                DeletedDate = deletedDate,
                DeletedDateSpecified = deletedDateSpecified
            };
        }

        public WS_NS_Policy_To_Del Init(String id)
        {
            return Init(id, DateTime.Now, false);
        }

        public WS_NS_Policy_To_Del WsNsPolicyToDel
        {
            get { return policyToDel; }
            set { policyToDel = value; }
        }
    }
}