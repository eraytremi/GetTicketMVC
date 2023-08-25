using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusFirm;

namespace GetTicketMVC.Areas.AdminPanel.Models.ViewModel
{
    public class BusViewModel
    {
        public List<BusList> BusesList { get; set; }
        public List<BusFirmList> BusFirmsList { get; set; }

    }
}
