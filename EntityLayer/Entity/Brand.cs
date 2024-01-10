﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Brand
	{
        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public string BrandImage { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
