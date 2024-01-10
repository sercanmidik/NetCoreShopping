using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class ProductSpecification
	{
        public int ProductSpecificationId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int SpecificationId { get; set; }
        public Specification Specification { get; set; }
        public string SpecificationValue { get; set; }
    }
}
