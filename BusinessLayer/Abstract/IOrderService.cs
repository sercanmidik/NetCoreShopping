using DtoLayer.OrderDtos;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
	public interface IOrderService : IGenericService<Order>
	{
        public int BusinessGetOrderIdUserIdTrue(int userId);
    }

}
