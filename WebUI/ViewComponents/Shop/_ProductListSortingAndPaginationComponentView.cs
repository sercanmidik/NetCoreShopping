using BusinessLayer.Abstract;
using DtoLayer.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace WebUI.ViewComponents.Shop
{
	public class _ProductListSortingAndPaginationComponentView:ViewComponent
	{
		private readonly IProductService _productService;

		public _ProductListSortingAndPaginationComponentView(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			List<ResultProductListDto> list = new List<ResultProductListDto>();
			var products = await _productService.BusinessGetAllWhereWithInculudeAsync(null, new string[] { "Category", "Brand" });
			if(products!=null)
			{
				foreach (var item in products)
				{
					list.Add(new ResultProductListDto
					{
						TotalPrice = item.TotalPrice,
						Title = item.Title,
						ImageUrl = item.ImageUrl,
						BrandName = item.Brand.BrandName,
						NotDiscountPrice = item.UnitPrice+(item.UnitPrice * item.TaxRate/100),
						ProductId = item.ProductId
					});
				}
			}
			var value=list.ToPagedList(1, 6);
            return View(value);
		}
	}
}
