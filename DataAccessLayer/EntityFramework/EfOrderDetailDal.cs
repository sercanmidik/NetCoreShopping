using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfOrderDetailDal : GenericRepository<OrderDetail>, IOrderDetailDal
	{
		private readonly ShoppingContext _shoppingContext;
		public EfOrderDetailDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{
			_shoppingContext = shoppingContext;
		}

        public int GetOrderUpdate(int productId, int order_id)
        {
            var value=_shoppingContext.OrderDetails.Where(x=>x.ProductId==productId && x.OrderId==order_id).FirstOrDefault();
			if (value != null)
			{
				return value.OrderDetailId;
			}
			else
			{
				return 0;
			}
        }
    }
}
