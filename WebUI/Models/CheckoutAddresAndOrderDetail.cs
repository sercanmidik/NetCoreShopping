using DtoLayer.OrderDetailDtos;
using EntityLayer.Entity;

namespace WebUI.Models
{
    public class CheckoutAddresAndOrderDetail
    {
        public Address? Address { get; set; }
        public IEnumerable<ResultOrderDetailDto> OrderDetails { get; set; }
    }
}
