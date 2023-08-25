using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusFirm;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;

namespace GetTicketMVC.Areas.AdminPanel.Models.ViewModel
{
    public class BusJourneyViewModel
    {
        public List<BusJourneyList> BusJourneysList { get; set; }
        public List<BusList> BusesList { get; set; }

    }
}
