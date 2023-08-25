using GetTicketMVC.ApiServices;
using GetTicketMVC.Areas.AdminPanel.Models.ApiTypes;
using GetTicketMVC.Areas.AdminPanel.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace AhlatciCourseProject.MvcUI.Areas.AdminPanel.Controllers
{
  [Area("AdminPanel")]
  public class AuthController : Controller
  {
    private readonly IHttpApiService _apiService;

    public AuthController(IHttpApiService apiService)
    {
      _apiService = apiService;
    }

    [HttpGet]
    public IActionResult LogIn()
    {
      return View();
    }

   
    [HttpPost]
    public async Task<IActionResult> LogIn(LogInDto dto)
    {
      string endPoint = $"/AdminPanelLogins/login?Email={dto.Email}&Password={dto.Password}";

      var response = 
        await _apiService.GetData<ResponseBody<AdminPanelUserItem>>(endPoint);

      if (response.StatusCode == 200)
      {
        HttpContext.Session.SetString("ActiveAdminPanelUser", JsonSerializer.Serialize(response.Data));

       await GetTokenAndSetInSession();
        return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
      }
      else
      {
        return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
      }
    }

        public async Task GetTokenAndSetInSession()
        {
            var response = await _apiService.GetData<ResponseBody<AccessTokenItem>>($"/AdminPanelLogins/gettoken");
            HttpContext.Session.SetString("AccessToken", JsonSerializer.Serialize(response.Data));
        }
  }
}
