using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusFirm;
using GetTicketMVC.Data;
using GetTicketMVC.Filters;
using GetTicketMVC.Models.ApiTypes;
using GetTicketMVC.Models.Dtos;
using GetTicketMVC.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Emit;

namespace GetTicketMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly CityDbContext _context;
        private readonly IHttpApiService _service;
        public HomeController(CityDbContext context, IHttpApiService service)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        [SessionPassengerLoginAspect]

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<GetBusJourney>>>("/busjourneys");
            var list = _context.CityModels.ToList();

            var searchModel = new SearchViewModel()
            {
                CityModel = list,
                GetBusJourneys = response.Data
            };
            return View(searchModel);
        }



        [HttpPost]
        public async Task<IActionResult> ControlSearch(SearchModelBus searchModel)
        {
            string endPoint = $"/BusJourneys/FindTicket?departurePoint={searchModel.DeparturePoint}&destinationPoint={searchModel.DestinationPoint}&departureTime={searchModel.DepartureTime.Date}";

            var response = await _service.GetData<ResponseBody<List<GetBusJourney>>>(endPoint);

            var getJourneyList = await GetJourneyList();

            var Model = new ListOfJourneyViewModel
            {
                BusJourneyDto = response.Data,
                GetJourneyDto = getJourneyList
            };

            if (response.Data != null)
            {
                return View("ListOfJourneys", Model);
            }
            else
            {
                ViewBag.NotFound = "Sefer Bulunamadı";
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public async Task<IActionResult> ListOfJourneys()
        {
            
            var response = await _service.GetData<ResponseBody<List<MyJourney>>>("/journeys");


            return View(response.Data);

        }


        private async Task<List<MyJourney>> GetJourneyList()
        {
            var response = await _service.GetData<ResponseBody<List<MyJourney>>>("/journeys");
            return response.Data;
        }
    }
}














//[HttpPost]
//public async Task<JsonResult> ControlSearch(SearchModelBus searchModel)
//{
//    string endPoint = $"/BusJourneys/FindTicket?departurePoint={searchModel.DeparturePoint}&destinationPoint={searchModel.DestinationPoint}&departureTime={searchModel.DepartureTime.Date}";

//    var response = await _service.GetData<ResponseBody<List<GetBusJourney>>>(endPoint);

//    if (response.Data != null)
//    {
//        return new JsonResult("1");
//    }
//    else
//    {
//        return new JsonResult("0");
//    }

//}
//[HttpPost]
//public async Task<IActionResult> ListOfJourneys(SearchModelBus searchModel)
//{
//    string endPoint = $"/BusJourneys/FindTicket?departurePoint={searchModel.DeparturePoint}&destinationPoint={searchModel.DestinationPoint}&departureTime={searchModel.DepartureTime.Date}";

//    var d = await _service.GetData<ResponseBody<List<GetBusJourney>>>(endPoint);
//    return View(d.Data);

//}