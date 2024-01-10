using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.ProductDtos
{
	public class ResultProductListDto
	{
		public int ProductId { get; set; }
		public string Title { get; set; }
		public string BrandName { get; set; }
		public decimal TotalPrice { get; set; }
		public decimal NotDiscountPrice { get; set; }
		public string ImageUrl { get; set; }
	}
}
