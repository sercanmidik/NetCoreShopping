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
	public class ProductSpecificationManager : IProductSpecificationService
	{
		private readonly IProductSpecificationDal _productSpecificationDal;

		public ProductSpecificationManager(IProductSpecificationDal productSpecificationDal)
		{
			_productSpecificationDal = productSpecificationDal;
		}
		public void BusinessAdd(ProductSpecification entity)
		{
			_productSpecificationDal.Add(entity);
		}
		public void BusinessDelete(ProductSpecification entity)
		{
			_productSpecificationDal.Delete(entity);
		}

		public async Task<IEnumerable<ProductSpecification>?> BusinessGetAllAsync()
		{
			return await _productSpecificationDal.GetAllAsync();
		}

		public async Task<IEnumerable<ProductSpecification>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<ProductSpecification, bool>>? expression = null, string[]? includes = null)
		{
			return await _productSpecificationDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public ProductSpecification BusinessGetById(int id)
		{
			return _productSpecificationDal.GetById(id);
		}

		public void BusinessUpdate(ProductSpecification entity)
		{
			_productSpecificationDal.Update(entity);
		}
	}
}
