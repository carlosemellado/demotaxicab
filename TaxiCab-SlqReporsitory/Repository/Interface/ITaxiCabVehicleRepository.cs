using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiCab_WebHooksApi.Models;

namespace TaxiCab_WebHooksApi.Repository
{
    public interface ITaxiCabVehicleRepository
    {
        ResultTransactionModel UpdateLocation(UpdateLocationModel model);
    }
}