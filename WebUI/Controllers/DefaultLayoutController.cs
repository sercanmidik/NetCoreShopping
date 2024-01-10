using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DefaultLayoutController : Controller
    {
        public IActionResult _Layoult()
        {
            return View();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult ScriptPartial()
        {
            return PartialView();
        }
        public PartialViewResult LoginPartial()
        {
            return PartialView();
        }
    }
}
