#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using DeepInWebApi.Models;
using System.Web.Script.Serialization;
using System.Net;
using WebApiContrib.Filters;

#endregion

namespace DeepInWebApi.Controllers
{
    public class ContractsController : ApiController
    {
        static List<ContactModel> contracts;

        static ContractsController()
        {
            contracts = new List<ContactModel>();

            contracts.Add(
                new ContactModel()
                {
                    Id = "001",
                    Name = "shangsan",
                    PhoneNo = "0571-89999999",
                    EmailAddress = "zhangshan@gmail.com",
                    Address = "hangzhoushiwangshanglu"
                }
                );
            contracts.Add(
                new ContactModel()
                {
                    Id = "0002",
                    Name = "lisi",
                    PhoneNo = "0571-988888888",
                    EmailAddress = "lisi@gmail.com",
                    Address = "hangzhouxiaoshanjichang"
                }
                );
        }
        /*
        public ContactModel Get(string id = null)
        {
            
            //HttpRequestMessage httpRequest = this.ActionContext.Request;

            return contracts[0];
        }
         */

        //[EnableCors]
      //  public HttpResponseMessage GetAllContacts(string callback)
      //  {

      //     ContactModel[] contacts = new ContactModel[]
      //     {

      //         new ContactModel{ Name="张三", PhoneNo="123", EmailAddress="zhangsan@gmail.com"},

      //         new ContactModel{ Name="李四", PhoneNo="456", EmailAddress="lisi@gmail.com"},

      //         new ContactModel{ Name="王五", PhoneNo="789", EmailAddress="wangwu@gmail.com"},

      //    };

      //    JavaScriptSerializer serializer = new JavaScriptSerializer();

      //    string content = string.Format("{0}({1})", callback, serializer.Serialize(contacts));

      //    return new HttpResponseMessage(HttpStatusCode.OK)
      //    {
      //         Content = new StringContent(content, Encoding.UTF8, "text/javascript")
      //    };
      //}

        public IEnumerable<ContactModel> Get(string id = null)
        {
            //HttpRequestMessage  httpRequest = this.ActionContext.Request.
            HttpRequestMessage httpRequest = this.ActionContext.Request;
            //foreach (var item in httpRequest.Headers) 
            //{
            //    Console.WriteLine("{Key:{0}:",item.Key.ToString());
            //    foreach(var str in item.Value)
            //    {
            //        Console.WriteLine("value:",str);
            //    }
            //    Console.Write("    ");
            //}
            var result = from contract in contracts
                         where contract.Id == id || string.IsNullOrEmpty(id)
                         select contract;
            return result;
        }

        public void Post(ContactModel contract)
        {
            contracts.Add(contract);
        }

        public void Put(ContactModel contract)
        {
            contracts.Remove(contracts.FirstOrDefault(c => c.Id == contract.Id));
            contracts.Add(contract);
        }

        public void Delete(string id)
        {
            contracts.Remove(contracts.First(c => c.Id == id));
        }
    }
}
