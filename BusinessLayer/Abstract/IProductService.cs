using DtoLayer.ProductDtos;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<Product>
    {
        public Task<IEnumerable<ResultProductDto>> GetDiscountProduct();
        public Task<IEnumerable<ResultCategoryCountListDto>> GetProductForCategoryCount();
        public Task<IEnumerable<ResultBrandCountListDto>> GetProductForBrandCount(); 
        public Task<ProductDetailDto> GetProductForProductDetail(int id);
    }
   
}
