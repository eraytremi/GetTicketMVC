using GetTicketMVC.Models.ApiTypes;

namespace GetTicketMVC.Models.ViewModel
{
    public class SearchViewModel
    {
        public List<CityModel> CityModel { get; set; }
        public List<GetBusJourney> GetBusJourneys { get; set; }  
    }
}
