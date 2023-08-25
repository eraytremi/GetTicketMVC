using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;

namespace GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney
{
    public class BusJourneyList
    {
        public int BusJourneyID { get; set; }
        public string? DestinationPoint { get; set; }
        public string? DeparturePoint { get; set; }
        public DateTime DepartureTime { get; set; }
        public decimal Price { get; set; }
        public BusList BusDto { get; set; }
    }
}
