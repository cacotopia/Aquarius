#region  "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.DataModel;

#endregion

namespace WebApi.Controller
{
    public class ContractsController :ApiController
    {
        static List<Contract> contracts;

        static ContractsController() 
        {
            contracts = new List<Contract>();
            contracts.Add(
                new Contract { }
                );
            contracts.Add(
                new Contract { }
                );
        }
    }
}
