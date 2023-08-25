using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Filters;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusFirm;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;
using GetTicketMVC.Areas.AdminPanel.Models.Dtos;
using GetTicketMVC.Areas.AdminPanel.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GetTicketMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class BusJourneyController : Controller
    {

        private readonly IHttpApiService _service;

        public BusJourneyController(IHttpApiService service)
        {
            _service = service;
        }



        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<BusJourneyList>>>("/busjourneys");

            var busList = await BusList();

            BusJourneyViewModel viewModel = new BusJourneyViewModel()
            {
                BusesList = busList,
                BusJourneysList=response.Data
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> InsertBusJourney(NewBusJourneyDto dto)
        {
            var response =
                 await _service.PostData<ResponseBody<PostBusJourney>>("/busjourneys", JsonSerializer.Serialize(dto));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Otobüs Seferi Başarıyla Kaydedildi" });



            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Otobüs bilgileri Kaydedilemedi <br /> {errorMessages}"
            });
        }


        //UPDATE

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var response = await _service.GetByIdData<ResponseBody<BusJourneyList>>("/busjourneys", id);

            var busList = await BusList();

            var ubjvm = new UpdateBusJourneyViewModel()
            {
                BusJourneyList = response.Data,
                BusLists=busList
            };
            return View(ubjvm);
        }



        [HttpPost]
        public async Task<IActionResult> Update(UpdateBusJourney dto)
        {
            var response = await _service.UpdateData<ResponseBody<BusJourneyList>>("/busjourneys", JsonSerializer.Serialize(dto));

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Otobüs Başarıyla Güncellendi" });



            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Otobüs bilgileri Güncellenemedi <br /> {errorMessages}"
            });
        }



        //REMOVE

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.RemoveData<ResponseBody<BusJourneyList>>("/busjourneys", id);
            return View(response);
        }



        private async Task<List<BusFirmList>> BusFirmList()
        {
            var response = await _service.GetData<ResponseBody<List<BusFirmList>>>("/busfirms");
            return response.Data;
        }
        private async Task<List<BusList>> BusList()
        {
            var response = await _service.GetData<ResponseBody<List<BusList>>>("/buses");
            return response.Data;
        }
    }
}
