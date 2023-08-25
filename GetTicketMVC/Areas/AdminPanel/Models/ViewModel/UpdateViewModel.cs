using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusFirm;

namespace GetTicketMVC.Areas.AdminPanel.Models.ViewModel
{
    public class UpdateViewModel
    {
        public List<BusFirmList> BusFirmsList { get; set; }
        public BusList BusList { get; set; }
    }
}
