using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.ProductDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
        private readonly ICategoryDal _categoryDal;
        private readonly IBrandDal _brandDal;
        private readonly ICommentDal _commentDal;
        private readonly IDescriptionDal _descriptionDal;
        private readonly IProductImageDal _productImageDal;
        private readonly IProductSpecificationDal _productSpecificationDal;
        private readonly IReviewDal _reviewDal;

		public ProductManager(IProductDal productDal, ICategoryDal categoryDal, IBrandDal brandDal, ICommentDal commentDal, IDescriptionDal descriptionDal, IProductImageDal productImageDal, IProductSpecificationDal productSpecificationDal, IReviewDal reviewDal)
		{
			_productDal = productDal;
			_categoryDal = categoryDal;
			_brandDal = brandDal;
			_commentDal = commentDal;
			_descriptionDal = descriptionDal;
			_productImageDal = productImageDal;
			_productSpecificationDal = productSpecificationDal;
			_reviewDal = reviewDal;
		}

		public void BusinessAdd(Product entity)
        {
            _productDal.Add(entity);
        }

        public void BusinessDelete(Product entity)
        {
            _productDal.Delete(entity);
        }

        public Task<IEnumerable<Product>?> BusinessGetAllAsync()
        {
            return _productDal.GetAllAsync();   
        }

        public Task<IEnumerable<Product>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Product, bool>>? expression = null, string[]? includes = null)
        {
            return _productDal.GetAllWhereWithInculudeAsync(expression, includes);
        }

        public Product BusinessGetById(int id)
        {
            return _productDal.GetById(id);
        }

        public void BusinessUpdate(Product entity)
        {
            _productDal.Update(entity);
        }

        public async Task<IEnumerable<ResultProductDto>> GetDiscountProduct()
        {
            List<ResultProductDto> result = new List<ResultProductDto>();
            var discountProduct = await _productDal.GetAllWhereWithInculudeAsync(x => x.Discount == true, new string[] { "Brand", "Category" });
            if(discountProduct != null)
            {
                foreach (var item in discountProduct)
                {
                    result.Add(new ResultProductDto
                    {
                        ProductId = item.ProductId,
                        BrandName = item.Brand.BrandName,
                        CategoryName = item.Category.CategoryName,
                        Price = item.Price,
                        ProductName = item.ProductName,
                        Title = item.Title,
                        TotalPrice = item.TotalPrice,
                        UnitPrice = item.UnitPrice,
                        NotDiscountPrice = item.UnitPrice + (item.UnitPrice * item.TaxRate) / 100,
                        ProductUrl=item.ImageUrl

                    });
                }
            }
            return result;
        }

		public async Task<IEnumerable<ResultBrandCountListDto>> GetProductForBrandCount()
		{
			List<ResultBrandCountListDto> result= new List<ResultBrandCountListDto>();
            var brandIds =await _productDal.GetBrandId();
            foreach (var brandId in brandIds)
            {
                var brandCount=await _productDal.GetBrandCount(brandId);
                result.Add(new ResultBrandCountListDto 
                { 
                    BrandCount = brandCount,
                    BrandName=_brandDal.GetById(brandId).BrandName
                });
            }
            return result;
		}

		public async Task<IEnumerable<ResultCategoryCountListDto>> GetProductForCategoryCount()
		{
			List<ResultCategoryCountListDto> result= new List<ResultCategoryCountListDto>();
            var categoryIds =await _productDal.GetCategoryId();
            foreach (var categoryId in categoryIds)
            {
                var categoryCount=await _productDal.GetProductCount(categoryId);
                result.Add(new ResultCategoryCountListDto
                {
                    CategoryCount = categoryCount,
                    CategoryName=_categoryDal.GetById(categoryId).CategoryName
                });
            }
            return result;
		}

		public async Task<ProductDetailDto> GetProductForProductDetail(int id)
		{

            var product = (await _productDal.GetAllWhereWithInculudeAsync(x => x.ProductId == id, new string[] { "Category", "Brand" })).FirstOrDefault();
            var comment= await _commentDal.GetAllWhereWithInculudeAsync(x => x.ProductId == id, new string[] { "AppUser" });
			var description = await _descriptionDal.GetAllWhereWithInculudeAsync(x => x.ProductId == id);
			var productImage = await _productImageDal.GetAllWhereWithInculudeAsync(x => x.ProductId == id);
			var specifications = await _productSpecificationDal.GetAllWhereWithInculudeAsync(x => x.ProductId == id,new string[] { "Specification" });
			var reviews = await _reviewDal.GetAllWhereWithInculudeAsync(x => x.ProductId == id,new string[] {"AppUser"});
			if (product != null)
            {
                ProductDetailDto resultDto = new ProductDetailDto()
                {
                    BrandName = product.Brand.BrandName,
                    ProductId = product.ProductId,
                    CategoryName = product.Category.CategoryName,
                    Comments=comment.ToList(),
                    Content=product.ProductName,
                    Title=product.Title,
                    Descriptions=description.ToList(),
                    Price=product.Price,
                    ProductImages=productImage.ToList(),
                    ProductSpecifications=specifications.ToList(),
                    Reviews= reviews.ToList(),
			    };
                return resultDto;
			}
            
			return new ProductDetailDto();
		}
	}
}
