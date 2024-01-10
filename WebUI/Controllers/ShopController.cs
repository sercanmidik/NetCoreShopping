using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;
using X.PagedList;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class ShopController : Controller
    {
        private readonly IProductService _productService;

		public ShopController(IProductService productService)
		{
			_productService = productService;
		}

		public IActionResult Index()
        {
            return View();
        }

	}
}
