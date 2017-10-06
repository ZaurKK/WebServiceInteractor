using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceInteractor.Model
{
    using WS_NS_Client = SKGeliosWebService.WS_NS_Client;
    using WS_NS_Policy = SKGeliosWebService.WS_NS_Policy;

    public class Policy
    {
        private IPolicyListener listener;
        private WS_NS_Policy policy;

        public Policy(IPolicyListener listener)
        {
            this.listener = listener;
        }

        public WS_NS_Policy Init(String id,
            DateTime creationDate, bool creationDateSpecified, DateTime payDate, bool payDateSpecified,
            DateTime startDate, bool startDateSpecified, DateTime endDate, bool endDateSpecified,
            WS_NS_Client insurer, bool insurerIsInsured, bool insurerIsInsuredSpecified, WS_NS_Client[] insureds,
            decimal tourPriceUE = 0, bool tourPriceUESpecified = false, String country = "", String townFrom = "", String claim = "", String policyNumber = "")
        {
            return policy = new WS_NS_Policy
            {
                Id = id,
                CreationDate = creationDate,
                CreationDateSpecified = creationDateSpecified,
                PayDate = payDate,
                PayDateSpecified = payDateSpecified,
                StartDate = startDate,
                StartDateSpecified = startDateSpecified,
                EndDate = endDate,
                EndDateSpecified = endDateSpecified,
                Insurer = insurer,
                InsurerIsInsured = insurerIsInsured,
                InsurerIsInsuredSpecified = insurerIsInsuredSpecified,
                Insureds = insureds,
                TourPriceUE = tourPriceUE,
                TourPriceUESpecified = tourPriceUESpecified,
                Country = country,
                TownFrom = townFrom,
                Claim = claim,
                PolicyNumber = policyNumber
            };
        }

        public WS_NS_Policy Init(String id, DateTime creationDate, DateTime payDate, DateTime startDate, DateTime endDate,
            WS_NS_Client insurer, bool insurerIsInsured, WS_NS_Client[] insureds,
            decimal tourPriceUE = 0, bool tourPriceUESpecified = false, String country = "", String townFrom = "", String claim = "", String policyNumber = "")
        {
            return Init(id, creationDate, true, payDate, true, startDate, true, endDate, true, insurer, insurerIsInsured, true, insureds,
                tourPriceUE, tourPriceUESpecified, country, townFrom, claim, policyNumber);
        }

        public WS_NS_Policy WsNsPolicy
        {
            get { return policy; }
            set { policy = value; }
        }
    }
}