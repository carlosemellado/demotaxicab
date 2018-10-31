using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiCab_WebHooksApi.Models;

namespace TaxiCab_SlqReporsitory
{
    public interface ITaxiCabJourneyRepository
    {
        ResultTransactionModel AcceptJourney(AcceptJourneyModel model);
        ResultTransactionModel RequestJourney(RequestJourneyModel model);
    }
}