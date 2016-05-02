#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DeepInWebApi.Models;

#endregion

namespace DeepInWebApi.Controllers
{
    //Route Prefix
    [RoutePrefix("api/v1/orders")]
    //[RoutePrefix("api/v1//orders/{customerId}")]
    public class OrdersController : ApiController
    {
        [Route("customers/{customerId}/orders")]
        [HttpGet]
        public IEnumerable<Order> FindOrdersByCustomer(int customerId) 
        {
            return null;
        }

        [Route("customers/{customerId}/{orders}/{orderId}")]
        public Order GetOrderByCustomer(int customerId, int orderId) 
        {
            return null;
        }

        [Route("")]
        public IEnumerable<Order> Get() 
        {
            return null;
        }

        //constrained parameter
        [Route("id:int")]
        public Order Get(int id) 
        {
            return null;
        }

        [Route("")]
        public HttpResponseMessage Post(Order order) 
        {
            //return NotFound();
            return null;
        }

        [Route("~/api/orders/{customerid:int}/orders")]
        public IEnumerable<Order> GetByCustomer(int customerId) 
        {
            return null;
        }
    }
}
