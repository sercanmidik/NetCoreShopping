using EntityLayer.Entity;

namespace DataAccessLayer.Abstract
{
    public interface IProductDal : IGenericDal<Product>
    {
        public Task<int> GetProductCount(int categoryId);
		public Task<int> GetBrandCount(int brandId);
		public Task<IEnumerable<int>> GetCategoryId();
		public Task<IEnumerable<int>> GetBrandId();
	}
}
