using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
		private readonly ShoppingContext _shoppingContext;
        public EfProductDal(ShoppingContext shoppingContext) : base(shoppingContext)
        {
			_shoppingContext = shoppingContext;
        }

		public async Task<int> GetBrandCount(int brandId)
		{
			var value = await _shoppingContext.Products.Where(x => x.BrandId == brandId).ToListAsync();
			return value.Count();
		}

		public async Task<IEnumerable<int>> GetBrandId()
		{
			var categoryIds = await _shoppingContext.Products
			.GroupBy(x => x.BrandId)
			.Select(group => group.Key)
			.ToListAsync();

			return categoryIds;
		}

		public async Task<IEnumerable<int>> GetCategoryId()
		{
			var categoryIds = await _shoppingContext.Products
			.GroupBy(x => x.CategoryId)
			.Select(group => group.Key)
			.ToListAsync();

			return categoryIds;
		}

		public async Task<int> GetProductCount(int categoryId)
		{
			var value = await _shoppingContext.Products.Where(x => x.CategoryId == categoryId).ToListAsync();
			return value.Count;
		}
	}
}
