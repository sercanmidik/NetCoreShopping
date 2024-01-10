using DtoLayer.FeatureDtos;
using EntityLayer.Entity;

namespace BusinessLayer.Abstract
{
    public interface IFeatureService : IGenericService<Feature>
    {
        public Task<IEnumerable<ResultFeatureDto>> GetFourFeatureAsync();
    }
   
}
