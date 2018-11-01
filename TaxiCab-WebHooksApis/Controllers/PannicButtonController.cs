using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaxiCab_WebHooksApi.Models;
using TaxyCab_Models.Constans;

namespace TaxiCab_WebHooksApis.Controllers
{
    public class PannicButtonController : ApiController
    {

        [HttpPost]
        [Route("api/vehicle/insident")]
        public HttpResponseMessage SendInsident(InsidenModel request)
        {
            var result = this.NotifyAsync(TaxiCabUtil.PANICBUTTON, new { Message = request });
            return Request.CreateResponse(HttpStatusCode.OK, new { resultado = "INCIDENTE ENVIADO" });
        }

    }
}
