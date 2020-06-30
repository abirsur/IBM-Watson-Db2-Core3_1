using Microsoft.AspNetCore.Mvc;

namespace APP27062020.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Account/Signin.cshtml");
        }

        [HttpPost]
        public IActionResult Login() {
            return RedirectToActionPermanent("index", "home");
        }

    }
}
