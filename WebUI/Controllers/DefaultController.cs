using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{

		public IActionResult Index()
		{
			return View();
		}
	}
}
