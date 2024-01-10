using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default
{
    public class _LastestProductsComponentPartialView:ViewComponent
    {
        private readonly IProductService _productService;

		public _LastestProductsComponentPartialView(IProductService productService)
		{
			_productService = productService;
		}

		public IViewComponentResult Invoke()
        {
            var values = _productService.GetDiscountProduct();
            return View(values);
        }
    }
}
