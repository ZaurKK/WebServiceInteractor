using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceInteractor.Model
{
    using WS_NS_Policy_Result = SKGeliosWebService.WS_NS_Policy_Result;

    public class PolicyResult
    {
        private IPolicyResultListener listener;
        private WS_NS_Policy_Result policyResult;

        public PolicyResult(IPolicyResultListener listener)
        {
            this.listener = listener;
        }

        public WS_NS_Policy_Result LoadPolicy(String serviceKey, Policy policy)
        {
            return policyResult = WebService.rustourService.LoadPolicy(serviceKey, policy.WsNsPolicy);
        }

        public WS_NS_Policy_Result DeletePolicy(String serviceKey, PolicyToDel policyToDel)
        {
            return policyResult = WebService.rustourService.DeletePolicy(serviceKey, policyToDel.WsNsPolicyToDel);
        }

        public WS_NS_Policy_Result WsNsPolicyResult
        {
            get { return policyResult; }
            set { policyResult = value; }
        }
    }
}
