using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ConfirmationController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAddress(CheckoutAddresAndOrderDetail model)
        {
            return RedirectToAction("Index", model);
        }
    }
}
