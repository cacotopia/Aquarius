﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeepInWebApi.Models
{
    public class ContactModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string PhoneNo { get; set; }

        public string EmailAddress { get; set; }

        public string Address { get; set; }
    }
}