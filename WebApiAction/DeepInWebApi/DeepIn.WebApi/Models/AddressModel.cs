#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#endregion

namespace DeepInWebApi.Models
{

    public class AddressModel
    {
        public int AddressId { get; set; }

        public string Address { get; set; }

        public string Address2 { get; set; }

        public string Distict { get; set; }

        public int CityId { get; set; }

        public string PostalCode { get; set; }

        public string Phone { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}