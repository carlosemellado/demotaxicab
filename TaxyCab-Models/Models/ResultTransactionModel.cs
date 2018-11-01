using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiCab_WebHooksApi.Models
{
    public class ResultTransactionModel
    {
        public int? numAffactedRows { get; set; }
        public string Description { get; set; }
    }
}