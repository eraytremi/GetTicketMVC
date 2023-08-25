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

    public class BusFirmController : Controller
    {
        private readonly IHttpApiService _service;

        public BusFirmController(IHttpApiService service)
        {
            _service = service;
        }

        //GET

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<BusFirmList>>>("/busfirms");
            return View(response.Data);
        }



        //ADD

        [HttpPost]
        public async Task<IActionResult> InsertBusFirm(NewBusFirmDto dto)
        {
            var response =
                 await _service.PostData<ResponseBody<BusFirmList>>("/busfirms", JsonSerializer.Serialize(dto));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Otobüs Firması Başarıyla Kaydedildi" });



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
            var response = await _service.GetByIdData<ResponseBody<BusFirmList>>("/busfirms", id);
            return View(response.Data);

        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateBusFirm dto)
        {
            var response = await _service.UpdateData<ResponseBody<BusFirmList>>("/busfirms", JsonSerializer.Serialize(dto));

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Otobüs Firması Başarıyla Güncellendi" });



            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Otobüs Firma bilgileri Güncellenemedi <br /> {errorMessages}"
            });
        }






        //REMOVE

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _service.RemoveData<ResponseBody<BusFirmList>>("/busfirms", id);
            return View(response);
        }



    }
}
