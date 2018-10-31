namespace TaxiCab_WebHooksApi.Models
{
    public class AcceptJourneyModel
    {

        public Journey journey { get; set; }
        public Driver driver { get; set; }
        public Vehicle vehicle { get; set; }
    }
}