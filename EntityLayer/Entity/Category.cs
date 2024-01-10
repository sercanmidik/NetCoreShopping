﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Category
	{
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
