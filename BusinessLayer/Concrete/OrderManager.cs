using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DtoLayer.OrderDtos;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class OrderManager : IOrderService
	{
		private readonly IOrderDal _orderDal;

		public OrderManager(IOrderDal orderDal)
		{
			_orderDal = orderDal;
		}

		public void BusinessAdd(Order entity)
		{
			_orderDal.Add(entity);
		}

		public void BusinessDelete(Order entity)
		{
			_orderDal.Delete(entity);
		}

		public Task<IEnumerable<Order>?> BusinessGetAllAsync()
		{
			return _orderDal.GetAllAsync();
		}

		public Task<IEnumerable<Order>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Order, bool>>? expression = null, string[]? includes = null)
		{
			return _orderDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public Order BusinessGetById(int id)
		{
			return _orderDal.GetById(id);
		}

        public int BusinessGetOrderIdUserIdTrue(int userId)
        {
			return _orderDal.GetOrderIdUserIdTrue(userId);
        }

        public void BusinessUpdate(Order entity)
		{
			_orderDal.Update(entity);
		}

	}
}
