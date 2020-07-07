using Microsoft.AspNetCore.Mvc;

namespace APPCOVID.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Account/Signin.cshtml");
        }

        [HttpPost]
        public IActionResult Login()
        {
            return RedirectToActionPermanent("index", "home");
        }

    }
}
