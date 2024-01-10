using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly ShoppingContext _shoppingContext;

        public GenericRepository(ShoppingContext shoppingContext)
        {
            _shoppingContext = shoppingContext;
        }

        public void Add(T entity)
        {
            _shoppingContext.Add(entity);
            _shoppingContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _shoppingContext.Remove(entity);
            _shoppingContext.SaveChanges();
        }

        public async Task<IEnumerable<T>?> GetAllAsync()
        {
            return await _shoppingContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>?> GetAllWhereWithInculudeAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null)
        {
            IQueryable<T> data = expression != null ? _shoppingContext.Set<T>().Where(expression) : _shoppingContext.Set<T>();
            if (data != null)
            {
                if (includes != null)
                {
                    foreach (var item in includes)
                    {
                        data = data.Include(item);
                    }
                }
            }
            return await Task.Run(() => data);
        }

        public T GetById(int id)
        {
            return _shoppingContext.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _shoppingContext.Update(entity);
            _shoppingContext.SaveChanges();
        }
    }
}
