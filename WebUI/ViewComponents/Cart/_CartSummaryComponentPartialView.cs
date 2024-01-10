using BusinessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Cart
{
	public class _CartSummaryComponentPartialView:ViewComponent
	{
		private readonly IOrderDetailService _orderDetailService;
		private readonly IOrderService _orderService;
		private readonly UserManager<AppUser> _userManager;

		public _CartSummaryComponentPartialView(IOrderDetailService orderDetailService, IOrderService orderService, UserManager<AppUser> userManager)
		{
			_orderDetailService = orderDetailService;
			_orderService = orderService;
			_userManager = userManager;
		}

		public async Task<string> InvokeAsync()
		{
			var user = await _userManager.GetUserAsync(HttpContext.User);
			int orderId = _orderService.BusinessGetOrderIdUserIdTrue(user.Id);
			var orderDetails = await _orderDetailService.BusinessGetAllWhereWithInculudeAsync(x => x.OrderId == orderId);
			if(orderDetails != null)
			{
                return orderDetails.Count().ToString();
            }
			return "0";
		}
	}
}
