using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiCab_WebHooksApi.Models
{
    public class RequestJourneyModel
    {
        public Client client { get; set; }
        public Location location { get; set; }
    }
}