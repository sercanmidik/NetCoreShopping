using DtoLayer.OrderDetailDtos;
using DtoLayer.OrderDtos;
using EntityLayer.Entity;

namespace WebUI.Models
{
	public class ConfirmAddressAndOrderAndOrderDetail
	{
		public Address? Address { get; set; }
		public Order? Order { get; set; }
		public IEnumerable<ResultOrderDetailDto> OrderDetails { get; set; }
	}
}
