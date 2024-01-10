using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	[AllowAnonymous]
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult CartBanner()
		{
			return PartialView();
		}
	}
}
