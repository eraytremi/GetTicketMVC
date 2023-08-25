

using GetTicketMVC.Models;
using GetTicketMVC.Models.ApiTypes;
using GetTicketMVC.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace LibrarySystem.Controllers
{
    public class SignInController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LogInDto dto)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7080/api");
                var responseMessage = await client.GetAsync($"{client.BaseAddress}/SignIn/login?email={dto.Email}&password={dto.Password}");

                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<ResponseBody<GetPassenger>>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (responseMessage.IsSuccessStatusCode)
                {
                    
                    HttpContext.Session.SetString("LoginUser", JsonSerializer.Serialize(response.Data));

                    return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }
            }

        }
    }
}
