using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfSpecificationDal : GenericRepository<Specification>, ISpecificationDal
	{
		public EfSpecificationDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{
		}
	}
}
