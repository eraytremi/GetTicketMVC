using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes.BusJourney;
using GetTicketMVC.Models.ApiTypes;
using GetTicketMVC.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GetTicketMVC.Controllers
{

    public class PaymentController : Controller
    {
        private readonly IHttpApiService _service;

        public PaymentController(IHttpApiService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PaymentTicket(string dto)
        {
            var response = await _service.PostData<ResponseBody<List<MyJourney>>>("/journeys", dto);
            if (response.StatusCode == 201)
                return Json(new { IsSuccess = true, Message = "Bilet Başarıyla Satın Alındı" });



            var errorMessages = string.Empty;


            foreach (var item in response.ErrorMessages)
            {
                errorMessages += item + "<br />";
            }

            return Json(new
            {
                IsSuccess = false,
                Message = $"Bilet satın alınamadı <br /> {errorMessages}"
            });
        }
    }
}
