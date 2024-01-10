using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        void BusinessAdd(T entity);
        void BusinessDelete(T entity);
        void BusinessUpdate(T entity);
        T BusinessGetById(int id);
        Task<IEnumerable<T>?> BusinessGetAllAsync();
        Task<IEnumerable<T>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null);
    }
}
