#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using DeepIn.DataModel;
using System.Net.Http;
using System.Net;

#endregion

namespace DeepIn.Controller
{
    public class ProductController :ApiController
    {
        private static IList<ProductModel> products = new List<ProductModel>() 
        {
            new ProductModel()
            {
                Id=1,
                Name= "Love song with you",
                Category ="Music",
                Price = 12M,
                ProductCode = 1,
                ShipDate = DateTime.Now.AddMonths(-1)
            },
            new ProductModel()
            {
                Id=2,
                Name= "Lover Letter",
                Category ="Game",
                Price = 120M,
                ProductCode = 2,
                ShipDate = DateTime.Now.AddMonths(-6)
            }
        };

        public ProductController() 
        {

        }

        public IEnumerable<ProductModel> Get() 
        {
            return products;
        }

        public HttpResponseMessage GetProduct(int id) 
        {
            var item = products.FirstOrDefault(p => p.Id == id);

            if (item == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK,item);
        }

        //public 
    }
}
