using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Security;
using TaxiCab_WebHooksApi.Models;
using TaxiCab_WebHooksApi.Repository;

namespace TaxiCab_WebHooksApi.Controllers
{
    [Authorize]
    public class JourneyController : ApiController
    {
        ITaxiCabJourneyRepository repository;
        public JourneyController(ITaxiCabJourneyRepository repository) {
            this.repository = repository;
        }
        

        [Route("api/journey/requestJourney")]
        [HttpPost()]
        public HttpResponseMessage RequestJourney(RequestJourneyModel request) {

            return Request.CreateResponse(HttpStatusCode.OK, repository.RequestJourney(request));

        }

        [Route("api/journey/acceptjourney")]
        [HttpPost()]
        public HttpResponseMessage AcceptJourney(AcceptJourneyModel request)
        {
            return Request.CreateResponse(HttpStatusCode.OK, repository.AcceptJourney(request));
        }


       


    }







}
