using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dependencies;
using System.Web.Security;
using TaxiCab_WebHooksApi.Models;
using TaxiCab_WebHooksApi.Repository;
using TaxyCab_Models.Constans;

namespace TaxiCab_WebHooksApi.Controllers
{
    [Authorize]
    public class VahicleController : ApiController
    {
        ITaxiCabVehicleRepository repository;
        public VahicleController(ITaxiCabVehicleRepository repository) {
            this.repository = repository;
        }
        [HttpPost]
        [Route("api/vehicle/updatelocation")]
        public HttpResponseMessage UpdateLocation(UpdateLocationModel request)
        {
            var result = this.NotifyAsync(TaxiCabUtil.VEHICLELOCATION, new { Message = request } );
            return Request.CreateResponse(HttpStatusCode.OK, repository.UpdateLocation(request));
        }
        [HttpPost]
        [Route("api/vehicle/gethistorylocations")]
        [HttpGet]
        public HttpResponseMessage GetLocations(GetLocationModel request)
        {
            var resultado = repository.GetLocations(request.vehicle, out request);

            return Request.CreateResponse(HttpStatusCode.OK, new { resultado= resultado, data = request });
        }


        [HttpPost]
        [Route("api/vehicle/getcurrentlocation")]
        [HttpGet]
        public HttpResponseMessage GetCurrectLocation(GetLocationModel request)
        {
            var resultado = repository.GetCurrentLocation(request.vehicle, out request);

            return Request.CreateResponse(HttpStatusCode.OK, new { resultado = resultado, data = request });
        }


       
    }







}
