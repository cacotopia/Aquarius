#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#endregion

namespace WebApi.DataModel
{
    public class Contract
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }
    }
}
