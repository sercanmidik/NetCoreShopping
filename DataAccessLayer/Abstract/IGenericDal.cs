using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        Task<IEnumerable<T>?> GetAllAsync();
        Task<IEnumerable<T>?> GetAllWhereWithInculudeAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null);
    }
}
