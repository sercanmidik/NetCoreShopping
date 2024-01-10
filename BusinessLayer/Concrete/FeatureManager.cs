using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.FeatureDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _featureDal;

        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void BusinessAdd(Feature entity)
        {
            _featureDal.Add(entity);
        }

        public void BusinessDelete(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public Task<IEnumerable<Feature>?> BusinessGetAllAsync()
        {
            return _featureDal.GetAllAsync();
        }

        public Task<IEnumerable<Feature>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Feature, bool>>? expression = null, string[]? includes = null)
        {
            return _featureDal.GetAllWhereWithInculudeAsync(expression, includes);
        }

        public Feature BusinessGetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public void BusinessUpdate(Feature entity)
        {
            _featureDal.Update(entity);
        }

		public async Task<IEnumerable<ResultFeatureDto>> GetFourFeatureAsync()
		{
			List<ResultFeatureDto> result = new List<ResultFeatureDto>();
            var values= await _featureDal.GetAllAsync();
            if (values!=null)
            {
                foreach (var item in values)
                {
                    result.Add(
                        new ResultFeatureDto {
                    FeatureId = item.FeatureId,
                    FeatureName = item.FeatureName,
                    FeatureContent = item.FeatureContent,
                    FeatureImage= item.FeatureImage,
                        });

                }
            }
            return result;
		}
	}
}
