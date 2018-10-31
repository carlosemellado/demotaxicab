using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TaxiCab_WebHooksApi.Repository;
using Unity;
using Unity.Lifetime;

namespace TaxiCab_WebHooksApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //
            var container = new UnityContainer();
            container.RegisterType<ITaxiCabJourneyRepository, TaxiCabJourneyRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ITaxiCabVehicleRepository, TaxiCabVehicleRepository>(new HierarchicalLifetimeManager());
         
            config.DependencyResolver = new UnityResolver(container);


            // Web API configuration and services
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.InitializeCustomWebHooks();
            config.InitializeCustomWebHooksApis();
        }
    }
}
