using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.DealsOfTheWeekDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DealsOfTheWeekManager : IDealsOfTheWeekService
    {
        private readonly IDealsOfTheWeekDal _dealsOfTheWeek;

        public DealsOfTheWeekManager(IDealsOfTheWeekDal dealsOfTheWeek)
        {
            _dealsOfTheWeek = dealsOfTheWeek;
        }

        public void BusinessAdd(DealsOfTheWeek entity)
        {
            _dealsOfTheWeek.Add(entity);
        }

        public void BusinessDelete(DealsOfTheWeek entity)
        {
            _dealsOfTheWeek.Delete(entity);
        }

        public Task<IEnumerable<DealsOfTheWeek>?> BusinessGetAllAsync()
        {
            return _dealsOfTheWeek.GetAllAsync();
        }

        public Task<IEnumerable<DealsOfTheWeek>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<DealsOfTheWeek, bool>>? expression = null, string[]? includes = null)
        {
            return _dealsOfTheWeek.GetAllWhereWithInculudeAsync(expression, includes);
        }

        public DealsOfTheWeek BusinessGetById(int id)
        {
            return _dealsOfTheWeek.GetById(id);
        }

        public void BusinessUpdate(DealsOfTheWeek entity)
        {
            _dealsOfTheWeek.Update(entity);
        }

		public async Task<IEnumerable<ResultDealsOfTheWeekDto>> GetDealsOfTheWeekNineProduct()
		{
			List<ResultDealsOfTheWeekDto> results=new List<ResultDealsOfTheWeekDto> ();
            var values = await _dealsOfTheWeek.GetAllWhereWithInculudeAsync(null, new string[] { "Product" });
            if(values!=null)
            {
                foreach (var item in values)
                {
                    results.Add(new ResultDealsOfTheWeekDto
                    {
                        BrandName = item.Product.Brand.BrandName,
                        ImageUrl = item.Product.ImageUrl,
                        NotDiscountPrice=item.Product.UnitPrice+(item.Product.UnitPrice*item.Product.TaxValue/100),
                        ProductId = item.Product.ProductId,
                        Title = item.Product.Title,
                        TotalPrice = item.Product.TotalPrice
                    });

				}

				
            }
            return results;
		}
	}
}
