using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNet.WebHooks;

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
                new WebHookFilter { Name = "AAA-AAA", Description = "VEHICLELOCATION"},
                new WebHookFilter { Name = "BBB-BBB", Description = "VEHICLELOCATION"},
                new WebHookFilter { Name = "VVV-002", Description = "VEHICLELOCATION"}
            };
        }

        public void AddVehicleFilter(string filter, string description)
        {
            filters.Add(new WebHookFilter { Name = filter, Description = description });
        }
    }


}