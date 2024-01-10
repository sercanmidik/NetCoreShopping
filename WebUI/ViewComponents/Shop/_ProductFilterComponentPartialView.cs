using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Shop
{
	public class _ProductFilterComponentPartialView:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View(); 
		}
	}
}
