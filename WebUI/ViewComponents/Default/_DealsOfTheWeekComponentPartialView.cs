using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default
{
	public class _DealsOfTheWeekComponentPartialView:ViewComponent
	{
		private readonly IDealsOfTheWeekService _dealsOfTheWeekService;

		public _DealsOfTheWeekComponentPartialView(IDealsOfTheWeekService dealsOfTheWeekService)
		{
			_dealsOfTheWeekService = dealsOfTheWeekService;
		}

		public IViewComponentResult Invoke()
		{
			var values=_dealsOfTheWeekService.GetDealsOfTheWeekNineProduct();
			return View(values);
		}
	}
}
