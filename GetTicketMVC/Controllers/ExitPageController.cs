using Microsoft.AspNetCore.Mvc;

namespace GetTicketMVC.Controllers
{
    public class ExitPageController : Controller
    {
        public IActionResult Quit()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
