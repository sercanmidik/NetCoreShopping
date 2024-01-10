using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Shop
{
    public class _GetCategoryCountComponentPartialView:ViewComponent
    {
        private readonly IProductService _productService;

		public _GetCategoryCountComponentPartialView(IProductService productService)
		{
			_productService = productService;
		}

		public IViewComponentResult Invoke()
        {
            var value = _productService.GetProductForCategoryCount();
            return View(value);
        }
    }
}
