using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default
{
	public class _BrandComponentPartialView:ViewComponent
	{
		private readonly IBrandService _brandService;

		public _BrandComponentPartialView(IBrandService brandService)
		{
			_brandService = brandService;
		}

		public IViewComponentResult Invoke()
		{
			var values = _brandService.GetBrand();
			return View(values);
		}
	}
}
