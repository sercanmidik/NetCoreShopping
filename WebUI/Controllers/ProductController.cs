using BusinessLayer.Abstract;
using DtoLayer.ProductDtos;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
	[AllowAnonymous]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;


		public ProductController(IProductService productService)
		{
			_productService = productService;

		}

		public IActionResult Detail(int productId)
		{
			var value=_productService.GetProductForProductDetail(productId);
			return View(value);
		}

		public PartialViewResult DetailBanner()
		{
			return PartialView();
		}
		
	}
}
