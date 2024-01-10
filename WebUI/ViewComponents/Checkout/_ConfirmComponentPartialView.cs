using BusinessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.ViewComponents.Checkout
{
    public class _ConfirmComponentPartialView:ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IOrderService _orderService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IAddressService _addressService;

		public _ConfirmComponentPartialView(UserManager<AppUser> userManager, IOrderService orderService, IOrderDetailService orderDetailService, IAddressService addressService)
		{
			_userManager = userManager;
			_orderService = orderService;
			_orderDetailService = orderDetailService;
			_addressService = addressService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
        {
			ConfirmAddressAndOrderAndOrderDetail model = new ConfirmAddressAndOrderAndOrderDetail();
            var user= await _userManager.GetUserAsync(HttpContext.User);
            int userId=user.Id;
            int orderId=_orderService.BusinessGetOrderIdUserIdTrue(userId);
            var adress=await _addressService.BusinessGetAllWhereWithInculudeAsync(x=>x.UserId==userId,new string[] { "AppUser" });
            if(adress!=null)
            {
				model.Address = adress.FirstOrDefault();
			}
            model.OrderDetails=_orderDetailService.GetByOrderId(orderId).Result;
			var orderdetail = _orderService.BusinessGetById(orderId);
			orderdetail.PayPal = true;
			orderdetail.Status = false;
            var values = await _orderDetailService.BusinessGetAllWhereWithInculudeAsync(x => x.OrderId == orderId);
            if(values!=null)
            {
				orderdetail.TotalOrder = 0;
				foreach (var item in values)
				{
					orderdetail.TotalOrder += item.TotalPrice;
				}
			}
            _orderService.BusinessUpdate(orderdetail);
			model.Order = _orderService.BusinessGetById(orderId);
			return View(model); 
        }

    }
}
