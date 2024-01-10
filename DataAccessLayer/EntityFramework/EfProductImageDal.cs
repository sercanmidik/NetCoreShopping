using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfProductImageDal : GenericRepository<ProductImage>, IProductImageDal
	{
		public EfProductImageDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{
		}
	}
}
