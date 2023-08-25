using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Models.ApiTypes;
using Microsoft.AspNetCore.Mvc;

namespace GetTicketMVC.Controllers
{
    public class TicketProcessController : Controller
    {
        private readonly IHttpApiService _service;

        public TicketProcessController(IHttpApiService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<MyJourney>>>("/journeys");
            
            return PartialView("_GetTicket",response.Data);
           
        }
    }
}
