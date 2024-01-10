using BusinessLayer.Abstract;
using EntityLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly IOrderDetailService _orderDetailService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public OrderDetailController(IOrderDetailService orderDetailService, UserManager<AppUser> userManager, IProductService productService, IOrderService orderService)
        {
            _orderDetailService = orderDetailService;
            _userManager = userManager;
            _productService = productService;
            _orderService = orderService;
        }
       
        public async Task<IActionResult> OrderDetailAdd(int productId)
        {
            var user= await _userManager.GetUserAsync(HttpContext.User);
            int userId=user.Id;
            var product=_productService.BusinessGetById(productId);
            int orderId=_orderService.BusinessGetOrderIdUserIdTrue(userId);
            if(orderId == 0)
            {
                Order order = new Order()
                {
                    UserId = userId,
                    Date = DateTime.Now,
                    Status = true
                };
                _orderService.BusinessAdd(order);
                orderId = _orderService.BusinessGetOrderIdUserIdTrue(userId);
            }
            int orderDetailId=_orderDetailService.BusinessGetOrderUpdate(productId, orderId);
            if(orderDetailId == 0)
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    OrderId = orderId,
                    ProductId = productId,
                    Price = product.Price,
                    TaxRate = product.TaxRate,
                    TaxValue = product.TaxValue,
                    Quantity = 1,
                    TotalPrice = product.TotalPrice,
                };
                _orderDetailService.BusinessAdd(orderDetail);
            }
            else
            {
                var value = _orderDetailService.BusinessGetById(orderDetailId);
                value.Quantity++;
                _orderDetailService.BusinessUpdate(value);
            }
            
            return RedirectToAction("Index", "Cart");
        }
    }
}
