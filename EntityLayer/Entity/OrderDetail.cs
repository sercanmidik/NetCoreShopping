﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class OrderDetail
	{
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
