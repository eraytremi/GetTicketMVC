namespace GetTicketMVC.Models.ApiTypes
{
    public class GetBusJourney
    {
        public int BusJourneyID { get; set; }
        public decimal Price { get; set; }
        public string DestinationPoint { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public BusModel BusDto { get; set; }

    }
}
