using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ProductDtos
{
    public class ResultProductDto
    {
        public int ProductId { get; set; }
        public string ProductUrl { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
        public string Title { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal NotDiscountPrice { get; set; }

    }
}
