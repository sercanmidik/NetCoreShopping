using DtoLayer.DealsOfTheWeekDtos;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IDealsOfTheWeekService : IGenericService<DealsOfTheWeek>
    {
        public Task<IEnumerable<ResultDealsOfTheWeekDto>> GetDealsOfTheWeekNineProduct();
    }
   
}
