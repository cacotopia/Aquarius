#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace DeepIn.DataModel
{
    public class ContractModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string EmailAddress { get; set; }

        public AddressModel Address { get; set; }
    }
}
