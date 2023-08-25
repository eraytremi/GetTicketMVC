namespace GetTicketMVC.Models.ApiTypes
{
    public class GetBusJourneyWithJourneyModel
    {
        public int BusJourneyID { get; set; }
        public decimal Price { get; set; }
        public string DestinationPoint { get; set; }
        public string DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
