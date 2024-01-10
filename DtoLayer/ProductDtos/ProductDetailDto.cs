using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ProductDtos
{
	public class ProductDetailDto
	{
        public int ProductId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public string Content { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<Description> Descriptions { get; set; }
        public List<ProductSpecification>? ProductSpecifications { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Review> Reviews { get; set; }


    }
}
