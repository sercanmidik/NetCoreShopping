using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Shop
{
    public class _ShopBannerComponentPartialView:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
