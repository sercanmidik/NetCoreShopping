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
	public class ReviewManager : IReviewService
	{
		private readonly IReviewDal _reviewDal;

		public ReviewManager(IReviewDal reviewDal)
		{
			_reviewDal = reviewDal;
		}

		public void BusinessAdd(Review entity)
		{
			_reviewDal.Add(entity);
		}

		public void BusinessDelete(Review entity)
		{
			_reviewDal.Delete(entity);
		}

		public async Task<IEnumerable<Review>?> BusinessGetAllAsync()
		{
			return await _reviewDal.GetAllAsync();
		}

		public Task<IEnumerable<Review>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Review, bool>>? expression = null, string[]? includes = null)
		{
			return _reviewDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public Review BusinessGetById(int id)
		{
			return _reviewDal.GetById(id);
		}

		public void BusinessUpdate(Review entity)
		{
			_reviewDal.Update(entity);
		}
	}
}
