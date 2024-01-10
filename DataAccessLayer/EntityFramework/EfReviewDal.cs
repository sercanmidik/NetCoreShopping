using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
	public class EfReviewDal : GenericRepository<Review>, IReviewDal
	{
		public EfReviewDal(ShoppingContext shoppingContext) : base(shoppingContext)
		{
		}
	}
}
