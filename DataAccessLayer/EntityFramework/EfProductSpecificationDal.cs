using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfProductSpecificationDal : GenericRepository<ProductSpecification>, IProductSpecificationDal
	{
		public EfProductSpecificationDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{
		}
	}
}
