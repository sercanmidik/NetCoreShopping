using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.OrderDetailDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class OrderDetailManager : IOrderDetailService
	{
		private readonly IOrderDetailDal _orderDetailDal;

		public OrderDetailManager(IOrderDetailDal orderDetailDal)
		{
			_orderDetailDal = orderDetailDal;
		}

		public void BusinessAdd(OrderDetail entity)
		{
			_orderDetailDal.Add(entity);
		}

		public void BusinessDelete(OrderDetail entity)
		{
			_orderDetailDal.Delete(entity);
		}

		public Task<IEnumerable<OrderDetail>?> BusinessGetAllAsync()
		{
			return _orderDetailDal.GetAllAsync();
		}

		public Task<IEnumerable<OrderDetail>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<OrderDetail, bool>>? expression = null, string[]? includes = null)
		{
			return _orderDetailDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public OrderDetail BusinessGetById(int id)
		{
			return _orderDetailDal.GetById(id);
		}

        public int BusinessGetOrderUpdate(int productId, int order_id)
        {
            return _orderDetailDal.GetOrderUpdate(productId, order_id);
        }

        public void BusinessUpdate(OrderDetail entity)
		{
			_orderDetailDal.Update(entity);
		}

        public async Task<IEnumerable<ResultOrderDetailDto>> GetByOrderId(int orderId)
        {
            List<ResultOrderDetailDto> result = new List<ResultOrderDetailDto>();
			var values = await _orderDetailDal.GetAllWhereWithInculudeAsync(x => x.OrderId == orderId, new string[] { "Order", "Product" });
			if(values!=null)
			{
				foreach( var value in values)
				{
					result.Add(new ResultOrderDetailDto()
					{
						OrderDetailId = value.OrderId,
						ProductName=value.Product.ProductName,
						ProductPrice=value.TotalPrice,
						TotalPrice=value.TotalPrice*value.Quantity,
						Quantity=value.Quantity,
						ProductUrl=value.Product.ImageUrl
					});
				}
			}
			return result;
        }
    }
}
