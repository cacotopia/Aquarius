using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace DeepIn.DataModel
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

        public DateTime ShipDate { get; set; }

        [JsonIgnore]
        public int ProductCode { get; set; } 
    }
}
