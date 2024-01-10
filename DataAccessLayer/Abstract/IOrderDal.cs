using EntityLayer.Entity;

namespace DataAccessLayer.Abstract
{
	public interface IOrderDal : IGenericDal<Order>
	{
		public int GetOrderIdUserIdTrue(int userId);
	}

}
