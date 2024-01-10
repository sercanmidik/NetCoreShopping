using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.BrandDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void BusinessAdd(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void BusinessDelete(Brand entity)
        {
            _brandDal.Delete(entity);
        }

        public Task<IEnumerable<Brand>?> BusinessGetAllAsync()
        {
            return _brandDal.GetAllAsync();
        }

        public Task<IEnumerable<Brand>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Brand, bool>>? expression = null, string[]? includes = null)
        {
            return _brandDal.GetAllWhereWithInculudeAsync(expression, includes);
        }

        public Brand BusinessGetById(int id)
        {
            return _brandDal.GetById(id);
        }

        public void BusinessUpdate(Brand entity)
        {
            _brandDal.Update(entity);
        }

        public async Task<IEnumerable<ResultBrandDto>> GetBrand()
        {
            List<ResultBrandDto> result = new List<ResultBrandDto>();
            var values = await _brandDal.GetAllAsync();
            if(values != null)
            {
                foreach(var value in values)
                {
                    result.Add(new ResultBrandDto
                    {
                        BrandImageUrl=value.BrandImage,
                    });
                }
            }
            return result;
        }
    }
}
