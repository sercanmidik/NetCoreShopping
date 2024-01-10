using EntityLayer.Entity;

namespace DataAccessLayer.Abstract
{
	public interface IOrderDetailDal : IGenericDal<OrderDetail>
	{
		public int GetOrderUpdate(int productId, int order_id);
	}

}
