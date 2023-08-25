using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;
using GetTicketMVC.Models.ApiTypes;

namespace GetTicketMVC.Models.ViewModel
{
    public class ListOfJourneyViewModel
    {
        public List<MyJourney>? GetJourneyDto { get; set; }
        public List<GetBusJourney>? BusJourneyDto { get; set; }
       
    }
}
