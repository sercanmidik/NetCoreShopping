using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ProductImageManager : IProductImageService
	{
		private readonly IProductImageDal _productImageDal;

		public ProductImageManager(IProductImageDal productImageDal)
		{
			_productImageDal = productImageDal;
		}

		public void BusinessAdd(ProductImage entity)
		{
			_productImageDal.Add(entity);
		}

		public void BusinessDelete(ProductImage entity)
		{
			_productImageDal.Delete(entity);
		}

		public async Task<IEnumerable<ProductImage>?> BusinessGetAllAsync()
		{
			return await _productImageDal.GetAllAsync();
		}

		public Task<IEnumerable<ProductImage>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<ProductImage, bool>>? expression = null, string[]? includes = null)
		{
			return _productImageDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public ProductImage BusinessGetById(int id)
		{
			return _productImageDal.GetById(id);
		}

		public void BusinessUpdate(ProductImage entity)
		{
			_productImageDal.Update(entity);
		}
	}
}
