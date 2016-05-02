#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DeepIn.ModelMapper.Model
{
    public class Address
    {
        public virtual int AddressId { get; set; }
        public virtual string Address1 { get; set; }
        public virtual  string Address2 { get; set; }
        public virtual string District { get; set; }
        public virtual int CityId { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual string Phone { get; set; }
        public virtual DateTime LastUpdate { get; set; }
    }
}
