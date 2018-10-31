using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace Receiver
{
    [RoutePrefix("api/webhook")]
    public class WebVehicleLocationController : ApiController
    {
        [HttpPost]
        [Route("")]
        public void Post(object message)
        {
            Console.WriteLine($"Received Vehiche Locations: {message}");
        }

        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get(string echo)
        {
            
            var resp = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(echo, Encoding.UTF8, "text/plain")
            };
            return resp;
        }
    }
}
