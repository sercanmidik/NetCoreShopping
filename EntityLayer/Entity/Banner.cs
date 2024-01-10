using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Banner
	{
        public int BannerId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
