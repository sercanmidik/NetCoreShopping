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
	public class CommentManager : ICommentService
	{
		private readonly ICommentDal _commentDal;

		public CommentManager(ICommentDal commentDal)
		{
			_commentDal = commentDal;
		}

		public void BusinessAdd(Comment entity)
		{
			_commentDal.Add(entity);
		}

		public void BusinessDelete(Comment entity)
		{
			_commentDal.Delete(entity);
		}

		public async Task<IEnumerable<Comment>?> BusinessGetAllAsync()
		{
			return await _commentDal.GetAllAsync();
		}

		public async Task<IEnumerable<Comment>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Comment, bool>>? expression = null, string[]? includes = null)
		{
			return await _commentDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public Comment BusinessGetById(int id)
		{
			return _commentDal.GetById(id);
		}

		public void BusinessUpdate(Comment entity)
		{
			_commentDal.Update(entity);
		}
	}
}
