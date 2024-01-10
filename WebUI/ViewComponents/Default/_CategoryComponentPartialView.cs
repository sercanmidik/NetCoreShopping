using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Default
{
    public class _CategoryComponentPartialView:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _CategoryComponentPartialView(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.GetCategory();
            return View(values);
        }
    }
}
