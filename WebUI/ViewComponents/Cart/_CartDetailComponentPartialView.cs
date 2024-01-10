using BusinessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Cart
{
    public class _CartDetailComponentPartialView:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;

        public _CartDetailComponentPartialView(UserManager<AppUser> userManager, IOrderService orderService, IOrderDetailService orderDetailService)
        {
            _userManager = userManager;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user= await _userManager.GetUserAsync(HttpContext.User);
            int userId=user.Id;
            int orderId=_orderService.BusinessGetOrderIdUserIdTrue(userId);
            if(orderId == 0)
            {
                Order order = new Order()
                {
                    UserId = userId,
                    Status = true,
                    TotalOrder = 0,
                    Date = DateTime.Now,
                };
                _orderService.BusinessAdd(order);
                orderId= _orderService.BusinessGetOrderIdUserIdTrue(userId);
            }
            var model=_orderDetailService.GetByOrderId(orderId);
            return View(model);
        }
    }
}
