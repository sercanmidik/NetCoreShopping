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
	public class SpecificationManager : ISpecificationService
	{
		private readonly ISpecificationDal _specificationDal;

		public SpecificationManager(ISpecificationDal specificationDal)
		{
			_specificationDal = specificationDal;
		}

		public void BusinessAdd(Specification entity)
		{
			_specificationDal.Add(entity);
		}

		public void BusinessDelete(Specification entity)
		{
			_specificationDal.Delete(entity);
		}

		public Task<IEnumerable<Specification>?> BusinessGetAllAsync()
		{
			return _specificationDal.GetAllAsync();
		}

		public Task<IEnumerable<Specification>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Specification, bool>>? expression = null, string[]? includes = null)
		{
			return _specificationDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public Specification BusinessGetById(int id)
		{
			return _specificationDal.GetById(id);
		}

		public void BusinessUpdate(Specification entity)
		{
			_specificationDal.Update(entity);
		}
	}
}
