using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;

namespace GetTicketMVC.Areas.AdminPanel.Models.ViewModel
{
    public class UpdateBusJourneyViewModel
    {
        public BusJourneyList BusJourneyList { get; set; }
        public List<BusList> BusLists { get; set; }
    }
}
