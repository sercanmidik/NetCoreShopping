using BusinessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.ViewComponents.Checkout
{
    public class _CheckoutComponentPartialView:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAddressService _addressService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;

        public _CheckoutComponentPartialView(UserManager<AppUser> userManager, IAddressService addressService, IOrderDetailService orderDetailService, IOrderService orderService)
        {
            _userManager = userManager;
            _addressService = addressService;
            _orderDetailService = orderDetailService;
            _orderService = orderService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            CheckoutAddresAndOrderDetail model= new CheckoutAddresAndOrderDetail();
            var user = await _userManager.GetUserAsync(HttpContext.User);
            int userId=user.Id;
            var address= await _addressService.BusinessGetAllWhereWithInculudeAsync(x=>x.UserId == userId,new string[] {"AppUser"});
            if(address!=null)
            {
                var first=address.FirstOrDefault();
                model.Address = first;
            }
            var orderId = _orderService.BusinessGetOrderIdUserIdTrue(userId);
            var orderDetailDtos = _orderDetailService.GetByOrderId(orderId);
            model.OrderDetails = orderDetailDtos.Result;
            return View(model);
        }
    }
}
