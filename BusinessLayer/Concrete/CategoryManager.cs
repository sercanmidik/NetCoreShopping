using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.CategoryDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void BusinessAdd(Category entity)
        {
            _categoryDal.Add(entity);   
        }

        public void BusinessDelete(Category entity)
        {
           _categoryDal.Delete(entity);
        }

        public Task<IEnumerable<Category>?> BusinessGetAllAsync()
        {
            return _categoryDal.GetAllAsync();
        }

        public Task<IEnumerable<Category>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Category, bool>>? expression = null, string[]? includes = null)
        {
            return _categoryDal.GetAllWhereWithInculudeAsync(expression,includes);
        }

        public Category BusinessGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public void BusinessUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }

        public async Task<IEnumerable<ResultCategoryDto>> GetCategory()
        {
            List<ResultCategoryDto> result = new List<ResultCategoryDto>();
            var values= await _categoryDal.GetAllAsync();
            if (values != null)
            {
                foreach (var value in values)
                {
                    result.Add(new ResultCategoryDto{
                        CategoryId=value.CategoryId,
                        CategoryImage=value.CategoryImage,
                        CategoryName=value.CategoryName,
                    });
                }
            }
            return result;
        }
    }
}
