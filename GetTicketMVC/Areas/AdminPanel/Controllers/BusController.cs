using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Filters;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusFirm;
using GetTicketMVC.Areas.AdminPanel.Models.Dtos;
using GetTicketMVC.Areas.AdminPanel.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GetTicketMVC.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]

    public class BusController : Controller
    {
        private readonly IHttpApiService _service;

        public BusController(IHttpApiService service)
        {
            _service = service;
        }


        //GET

        [HttpGet]
        public async  Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<BusList>>>("/buses");

            var busFirmLists = await BusFirmList();

            BusViewModel model = new BusViewModel()
            {
                BusesList = response.Data.ToList(),
                BusFirmsList = await BusFirmList()
            };

           return View(model);
        }



        //INSERT

        [HttpPost]
        public async Task<IActionResult> InsertBus(NewBusDto dto)
        {
            var response = 
                 await _service.PostData<ResponseBody<PostBus>>("/buses", JsonSerializer.Serialize(dto));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Otobüs Başarıyla Kaydedildi" });
            
            
            
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
            var response = await _service.GetByIdData<ResponseBody<BusList>>("/buses",id);

            var busFirmList= await BusFirmList();

            var ubvm = new UpdateViewModel()
            {
                BusFirmsList = busFirmList,
                BusList= response.Data
            };
            return View(ubvm);
        }


        [HttpPost]
        public async Task<IActionResult> Update(PostBus dto)
        {
            var response = await _service.UpdateData<ResponseBody<UpdateBus>>("/buses", JsonSerializer.Serialize(dto));

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
            var response = await _service.RemoveData<ResponseBody<BusList>>("/buses", id);
            return View(response);
        }



        private async Task<List<BusFirmList>> BusFirmList()
        {
            var response = await _service.GetData<ResponseBody<List<BusFirmList>>>("/busfirms");
            return response.Data;
        }

    }
}
