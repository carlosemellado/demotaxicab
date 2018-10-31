using System.Web.Http;
using System.Web.Http.Tracing;
using Microsoft.AspNet.WebHooks.Controllers;
using Owin;

namespace TaxiCab_Client
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            var controllerType = typeof (WebHookReceiversController);
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }
                );

            config.InitializeReceiveCustomWebHooks();

            config.EnsureInitialized();

            var traceWriter = config.EnableSystemDiagnosticsTracing();
            traceWriter.IsVerbose = true;
            traceWriter.MinimumLevel = TraceLevel.Error;

            appBuilder.UseWebApi(config);
        }
    }
}