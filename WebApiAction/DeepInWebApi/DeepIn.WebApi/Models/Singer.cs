#region "Imports"

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#endregion

namespace DeepInWebApi.Models
{
    public class Singer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string Debut { get; set; }

    }
}