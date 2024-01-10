using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfDescriptionDal : GenericRepository<Description>, IDescriptionDal
	{
		public EfDescriptionDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{
		}
	}
}
