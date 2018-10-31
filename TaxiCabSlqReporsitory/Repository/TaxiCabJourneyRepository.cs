using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiCab_WebHooksApi.Models;

namespace TaxiCab_SlqReporsitory
{
    public class TaxiCabJourneyRepository : ITaxiCabJourneyRepository
    {
        public ResultTransactionModel AcceptJourney(AcceptJourneyModel model)
        {
            return new ResultTransactionModel() { numAffactedRows = 1, Description = "" };
        }

        public ResultTransactionModel RequestJourney(RequestJourneyModel model)
        {
            return new ResultTransactionModel() { numAffactedRows = 1, Description = "" };
        }
    }
}