using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiCab_WebHooksApi.Models;

namespace TaxiCab_WebHooksApi.Repository
{
    public class TaxiCabVehicleRepository : ITaxiCabVehicleRepository
    {
        public ResultTransactionModel UpdateLocation(UpdateLocationModel model)
        {
            return new ResultTransactionModel() { numAffactedRows = 1, Description = "" };
        }
    }
}