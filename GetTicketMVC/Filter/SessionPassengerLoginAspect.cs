using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GetTicketMVC.Filters
{
  public class SessionPassengerLoginAspect:ActionFilterAttribute
  {
    // metod ilk tetiklendiğinde session ı kontrol etsin
    public override void OnActionExecuting(ActionExecutingContext context)
    {
      var sessionData = context.HttpContext.Session.GetString("LoginUser");

      if (string.IsNullOrEmpty(sessionData))
        context.Result = new RedirectResult("/SignIn/Login");

        }
  }
}
