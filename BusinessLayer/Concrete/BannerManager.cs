using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.BannerDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BannerManager : IBannerService
    {
        private readonly IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public void BusinessAdd(Banner entity)
        {
            _bannerDal.Add(entity);
        }

        public void BusinessDelete(Banner entity)
        {
           _bannerDal.Delete(entity);
        }

        public Task<IEnumerable<Banner>?> BusinessGetAllAsync()
        {
            return _bannerDal.GetAllAsync();
        }

        public Task<IEnumerable<Banner>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Banner, bool>>? expression = null, string[]? includes = null)
        {
            return _bannerDal.GetAllWhereWithInculudeAsync(expression, includes);
        }

        public Banner BusinessGetById(int id)
        {
            return _bannerDal.GetById(id);
        }

        public void BusinessUpdate(Banner entity)
        {
            _bannerDal.Update(entity);
        }

        public async Task<IEnumerable<ResultBannerProductDto>> GetBannerWithProductAsync()
        {
            List<ResultBannerProductDto> model=new List<ResultBannerProductDto>();
            var values = await _bannerDal.GetAllWhereWithInculudeAsync(null, new string[] { "Product" });
            if (values != null)
            {
                foreach (var item in values)
                {
                    model.Add(new ResultBannerProductDto
                    {
                        BannerContent = item.Product.BannerContent,
                        BannerImageUrl = item.Product.BannerImageUrl,
                        ProductId = item.ProductId,
                        BannerTitleOne = item.Product.BannerTitleOne,
                        BannerTitleTwo = item.Product.BannerTitleTwo,
                    });
                }
            }
           
            return model;
        }
    }
}
