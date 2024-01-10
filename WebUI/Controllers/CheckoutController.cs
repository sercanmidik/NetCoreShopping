using BusinessLayer.Abstract;
using DtoLayer.AdressDtos;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
	[AllowAnonymous]
	public class CheckoutController : Controller
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IOrderService _orderService;
		private readonly IOrderDetailService _orderDetailService;

        public CheckoutController(UserManager<AppUser> userManager, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        public IActionResult Index()
		{
			return View();
		}
		public PartialViewResult CheckoutPartial()
		{
			return PartialView();
		}
		
	}
}
