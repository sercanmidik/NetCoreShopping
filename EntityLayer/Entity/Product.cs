using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Product
	{
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string ProductName { get; set; }
        public string? BannerTitleOne { get; set; }
        public string? BannerTitleTwo { get; set; }
        public string? BannerContent { get; set; }
        public string? BannerImageUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public bool Discount { get; set; }
        public decimal DiscountRate { get; set; }
        public decimal Price { get; set; }
        public decimal TaxRate { get; set; }
        public decimal TaxValue { get; set; }
        public decimal TotalPrice { get; set; }
        public Banner? Banner { get; set; }
        public DealsOfTheWeek? DealsOfTheWeek { get; set; }
        public ICollection<Description> Descriptions { get; set; }
        public ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
