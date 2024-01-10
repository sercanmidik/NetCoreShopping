using DtoLayer.BannerDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IBannerService:IGenericService<Banner>
    {
        public Task<IEnumerable<ResultBannerProductDto>> GetBannerWithProductAsync();
    }

}
