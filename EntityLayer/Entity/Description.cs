using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Description
	{
        public int DescriptionId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Content { get; set; }
    }
}
