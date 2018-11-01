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
            var result = this.NotifyAllAsync(request.vehicle.vehicleId, new { Message = request } );
            return Request.CreateResponse(HttpStatusCode.OK, repository.UpdateLocation(request));
        }
        [HttpPost]
        [Route("api/vehicle/getlocations")]
        [HttpGet]
        public HttpResponseMessage GetLocations(GetLocationModel request)
        {
            var resultado = repository.GetLocations(request.vehicle, out request);

            return Request.CreateResponse(HttpStatusCode.OK, new { resultado= resultado, data = request });
        }
    }







}
