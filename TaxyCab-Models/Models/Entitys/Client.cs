using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiCab_WebHooksApi.Models
{
    public class Client
    {
        public string clientCode { get; set; }
        public string phoneNumber { get; set; }
        public string clientName { get; set; }
    }
}