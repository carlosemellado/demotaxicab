using System.Collections.Generic;

namespace TaxiCab_WebHooksApi.Models
{
    public class InsidenModel
    {
        public Vehicle vehicle { get; set; }

        public List<Location> locations { get; set; }


        public Insident insident { get; set; }
    }
}