
using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;
using GetTicketMVC.Models;
using GetTicketMVC.Models.ApiTypes;
using GetTicketMVC.Models.Dtos;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace LibrarySystem.Controllers
{
    public class SignUpController : Controller
    {
        private readonly IHttpApiService _service;
        private readonly IWebHostEnvironment _webHost;
        public SignUpController(IHttpApiService service, IWebHostEnvironment webHost)
        {
            _service = service;
            _webHost = webHost;
        }

        [HttpGet]
        public   IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto register)
        {

            var response =
                   await _service.PostData<ResponseBody<GetPassenger>>("/registers", JsonSerializer.Serialize(register));

            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Başarılı Bir Şekilde Kayıt Oldun.. Giriş Yapabilirsin" });



            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item;
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Kayıt Başarılı Değil! Tekrar Dene..  {errorMessages}"
            });
        }
          
    }
}
