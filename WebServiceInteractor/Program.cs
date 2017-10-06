using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceInteractor
{
    class Program
    {
        static void Main(string[] args)
        {
            PolicyHandler policyHandler = new PolicyHandler();
            //policyHandler.LoadPolicy();
            policyHandler.DeletePolicy();
        }
    }
}
