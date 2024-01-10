using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Specification
	{
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        public ICollection<ProductSpecification> ProductSpecifications { get; set; }
    }
}
