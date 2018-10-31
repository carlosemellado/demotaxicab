using System.Collections.Generic;

namespace TaxiCab_WebHooksApi.Models
{
    public class UpdateLocationModel
    {
        public Vehicle vehicle { get; set; }

        public List<Location> locations { get; set; }

    }
}