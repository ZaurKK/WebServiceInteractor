using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceInteractor
{
    class PolicyHandler : Model.IClientListener, Model.IPolicyListener, Model.IPolicyToDelListener, Model.IPolicyResultListener
    {
        private DateTime now;
        private String serviceKey;

        public void Init()
        {
            now = DateTime.Now;
            serviceKey = WebService.CreateServiceKey(now);
        }

        public void LoadPolicy()
        {
            Init();
            String key = now.ToShortDateString() + "_" + now.ToLongTimeString() + "_";

            Model.Client insurer = new Model.Client(this);
            insurer.Init("FirstName_" + key + 0, "LastName_" + key + 0, now.AddYears(-50));
            List<Model.Client> insureds = new List<Model.Client>();
            for (int i = 0; i < 3; i++)
            {
                Model.Client insured = new Model.Client(this);

                insured.Init("FirstName_" + key + (i + 1), "LastName_" + key + (i + 1), now.AddYears(-50));
                insureds.Add(insured);
            }
            Model.Policy policy = new Model.Policy(this);
            policy.Init(key, now, now, now, now.AddHours(8), insurer.WsNsClient, true, insureds.Select(item => item.WsNsClient).ToArray());

            Model.PolicyResult policyResult = new Model.PolicyResult(this);
            policyResult.LoadPolicy(serviceKey, policy);
        }

        public void DeletePolicy()
        {
            Init();

            Model.PolicyToDel policyToDel = new Model.PolicyToDel(this);
            policyToDel.Init("id_2", now);

            Model.PolicyResult policyResult = new Model.PolicyResult(this);
            policyResult.DeletePolicy(serviceKey, policyToDel);
        }
    }
}
