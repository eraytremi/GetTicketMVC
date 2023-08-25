using GetTicketMVC.Areas.AdminPanel.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AhlatciCourseProject.MvcUI.Areas.AdminPanel.Controllers
{
  [Area("AdminPanel")]
  [SessionControlAspect]
  public class HomeController : Controller
  {
    [LogAspect]
    public IActionResult Index()
    {
      return View();
    }


  }
}
