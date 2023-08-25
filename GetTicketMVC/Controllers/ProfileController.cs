using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.Bus;
using GetTicketMVC.Models.ApiTypes;
using GetTicketMVC.Models.Dtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GetTicketMVC.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IHttpApiService _service;

        public ProfileController(IHttpApiService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<GetPassenger>>>("/passengers");
            return View(response.Data);
        }
    

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProfileDto dto)
        {
            var response = await _service.UpdateData<ResponseBody<GetPassenger>>("/passengers", JsonSerializer.Serialize(dto));

            if (response.StatusCode == 200 || response.ErrorMessages == null)
                return Json(new { IsSuccess = true, Message = "Profil Bilgileri Başarıyla Güncellendi" });


            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Profil bilgileri Güncellenemedi <br /> {errorMessages}"
            });
        }

        [HttpGet]
        public async Task<IActionResult> MyJourney(int id)
        {
           
            var response = await _service.GetData<ResponseBody<List<MyJourney>>>($"/Journeys/getbypassengerid?id={id}");
            return View(response.Data);
        }


    }
}
