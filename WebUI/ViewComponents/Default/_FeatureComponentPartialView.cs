using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default
{
	public class _FeatureComponentPartialView:ViewComponent
	{
		private readonly IFeatureService _featureService;

		public _FeatureComponentPartialView(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		public IViewComponentResult Invoke()
		{
			var value = _featureService.GetFourFeatureAsync();
			return View(value);
		}
	}
}
