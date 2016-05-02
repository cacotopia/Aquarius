#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DeepIn.DataModel;
using System.Net.Http;

#endregion

namespace DeepIn.Controller
{

    public class ContractsController :ApiController
    {
        static List<ContractModel> contracts;

        static ContractsController() 
        {
            contracts = new List<ContractModel>();

            //contracts.Add(
            //    new ContractModel() { 
            //    Id="001",Name="张珊",PhoneNo="0571-89999999",
            //    EmailAddress="zhangshan@gmail.com"
            //    //Address = "杭州市滨江区网商路"}
            //    );
            //contracts.Add(
            //    new ContractModel() { 
            //    Id="0002",Name="李四",PhoneNo = "0571-988888888",EmailAddress="lisi@gmail.com"
            //    //Address="杭州市萧山机场迎宾大道"
            //    }
            //    );
        }

        public IEnumerable<ContractModel> Get(string id = null) 
        {
            //HttpRequestMessage  httpRequest = this.ActionContext.Request.
            return from contract in contracts
                   where contract.Id == id || string.IsNullOrEmpty(id)
                   select contract;
        }

        public void Post(ContractModel contract) 
        {           
            contracts.Add(contract);
        }        
        
        public void Put(ContractModel contract) 
        {
            contracts.Remove(contracts.FirstOrDefault(c=>c.Id== contract.Id));
            contracts.Add(contract);
        }

        public void Delete(string id) 
        {
            contracts.Remove(contracts.First(c=>c.Id == id));
        }
    }
}
