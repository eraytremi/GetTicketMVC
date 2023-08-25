
using System.ComponentModel.DataAnnotations;

namespace GetTicketMVC.Models.ViewModel
{
    public class CityModel
    {
       
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }
    }
}
