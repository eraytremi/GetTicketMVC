using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Filters;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Journey;
using GetTicketMVC.Areas.AdminPanel.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GetTicketMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class JourneyController : Controller
    {
       

        private readonly IHttpApiService _service;

        public JourneyController(IHttpApiService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var jsonTokenData = HttpContext.Session.GetString("AccessToken");
            var jwt = JsonSerializer.Deserialize<AccessTokenItem>(jsonTokenData); 
            var response = await _service.GetData<ResponseBody<List<JourneyList>>>("/journeys",jwt.Token);
            return View(response.Data);
        }
    }
}
