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
	public class DescriptionManager : IDescriptionService
	{
		private readonly IDescriptionDal _descriptionDal;

		public DescriptionManager(IDescriptionDal descriptionDal)
		{
			_descriptionDal = descriptionDal;
		}

		public void BusinessAdd(Description entity)
		{
			_descriptionDal.Add(entity);
		}

		public void BusinessDelete(Description entity)
		{
			_descriptionDal.Delete(entity);
		}

		public async Task<IEnumerable<Description>?> BusinessGetAllAsync()
		{
			return await _descriptionDal.GetAllAsync();
		}

		public async Task<IEnumerable<Description>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Description, bool>>? expression = null, string[]? includes = null)
		{
			return await _descriptionDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public Description BusinessGetById(int id)
		{
			return _descriptionDal.GetById(id);
		}

		public void BusinessUpdate(Description entity)
		{
			_descriptionDal.Update(entity);
		}
	}
}
