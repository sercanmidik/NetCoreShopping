using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfAddressDal : GenericRepository<Address>, IAddressDal
	{
		public EfAddressDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{
		}
	}
}
