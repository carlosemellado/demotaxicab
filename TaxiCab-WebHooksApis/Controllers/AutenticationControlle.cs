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
   
    public class AutenticationController : ApiController
    {
        

        [Route("api/journey/auth/signin")]
        [HttpPost()]
        public HttpResponseMessage Signin(User user)
        {
            FormsAuthentication.SetAuthCookie(user.name, false);
            return Request.CreateResponse(HttpStatusCode.OK, new { user = $"Authentication Successfull: {user.name}",  });
        }

        [Route("api/journey/auth/signout")]
        [HttpPost()]
        public HttpResponseMessage SignOut(User user)
        {
            FormsAuthentication.SignOut();
            return Request.CreateResponse(HttpStatusCode.OK, new { user = $"SignOut Successfull: {user.name}",  });
        }


        

    }







}
