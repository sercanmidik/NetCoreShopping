using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default
{
	public class _BannerComponentPartialView:ViewComponent
	{
		private readonly IBannerService _bannerService;

        public _BannerComponentPartialView(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IViewComponentResult Invoke()
		{
			var values = _bannerService.GetBannerWithProductAsync();
			return View(values);
		}
	}
}
