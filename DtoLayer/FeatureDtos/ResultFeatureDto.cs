using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.FeatureDtos
{
	public class ResultFeatureDto
	{
		public int FeatureId { get; set; }
		public string FeatureName { get; set; }
		public string FeatureContent { get; set; }
		public string FeatureImage { get; set; }
	}
}
