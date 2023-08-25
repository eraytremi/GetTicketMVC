using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Passenger;

namespace GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Journey
{
    public class JourneyList
    {
        public int? SeatNo { get; set; }
        public BusJourneyList? BusJourneyDto { get; set; }
        public GetPassengerList? GetPassengerDto { get; set; }
    }
}
