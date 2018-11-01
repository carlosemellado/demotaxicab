using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;
using TaxyCab_Models.Constans;

namespace WebApiHost
{
    public class WebHookFilterProvider : IWebHookFilterProvider
    {
        public Task<Collection<WebHookFilter>> GetFiltersAsync()
        {
            return Task.FromResult(VehiclesFilters.Instance.filters);
        }
    }




    public sealed class VehiclesFilters
    {

        public Collection<WebHookFilter> filters;

        private static readonly Lazy<VehiclesFilters> lazy =
        new Lazy<VehiclesFilters>(() => new VehiclesFilters());

        public static VehiclesFilters Instance { get { return lazy.Value; } }

        private VehiclesFilters()
        {
            filters = new Collection<WebHookFilter>
            {
                new WebHookFilter { Name = TaxiCabUtil.VEHICLELOCATION, Description = "Notificaciones para ubicaciones de vehiculos"},
                new WebHookFilter { Name = TaxiCabUtil.PANICBUTTON, Description = "Notificaciones para problemas durante el viaje"},
            };
        }

        public void AddVehicleFilter(string filter, string description)
        {
            filters.Add(new WebHookFilter { Name = filter, Description = description });
        }
    }


}