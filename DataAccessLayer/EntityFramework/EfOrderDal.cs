using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		private readonly ShoppingContext _shoppingContext;
		public EfOrderDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{ 
			_shoppingContext = shoppingContext;
		}

        public int GetOrderIdUserIdTrue(int userId)
        {
            return _shoppingContext.Orders.Where(x=>x.UserId == userId && x.Status==true).Select(x=>x.OrderId).FirstOrDefault();
        }
    }
}
