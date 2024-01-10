using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Shop
{
	public class _GetBrandCountComponentPartialView:ViewComponent
	{
		private readonly IProductService _productService;

        public _GetBrandCountComponentPartialView(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
		{
			var values = _productService.GetProductForBrandCount();
			return View(values);
		}
	}
}
