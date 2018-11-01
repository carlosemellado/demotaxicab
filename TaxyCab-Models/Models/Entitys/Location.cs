using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiCab_WebHooksApi.Models
{
    public class Location
    {
        public DateTime datetime;

        public string latitud { get; set; }
        public string longitud { get; set; }
        public string contryCode { get; set; }
        public string stateCode { get; set; }
        public string tonwCode { get; set; }
        public string adress { get; set; }
    }

}