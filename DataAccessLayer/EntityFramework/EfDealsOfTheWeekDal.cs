using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;

namespace DataAccessLayer.EntityFramework
{
    public class EfDealsOfTheWeekDal : GenericRepository<DealsOfTheWeek>, IDealsOfTheWeekDal
    {
        public EfDealsOfTheWeekDal(ShoppingContext shoppingContext) : base(shoppingContext)
        {
        }
    }
}
