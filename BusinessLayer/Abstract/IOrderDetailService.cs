using DtoLayer.OrderDetailDtos;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
	public interface IOrderDetailService : IGenericService<OrderDetail>
	{
		public Task<IEnumerable<ResultOrderDetailDto>> GetByOrderId(int orderId);
		public int BusinessGetOrderUpdate(int productId, int order_id);

    }

}
