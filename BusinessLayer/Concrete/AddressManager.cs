using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class AddressManager : IAddressService
	{
		private readonly IAddressDal _addressDal;

		public AddressManager(IAddressDal addressDal)
		{
			_addressDal = addressDal;
		}

		public void BusinessAdd(Address entity)
		{
			_addressDal.Add(entity);
		}

		public void BusinessDelete(Address entity)
		{
			_addressDal.Delete(entity);
		}

		public Task<IEnumerable<Address>?> BusinessGetAllAsync()
		{
			return _addressDal.GetAllAsync();	
		}

		public Task<IEnumerable<Address>?> BusinessGetAllWhereWithInculudeAsync(Expression<Func<Address, bool>>? expression = null, string[]? includes = null)
		{
			return _addressDal.GetAllWhereWithInculudeAsync(expression, includes);
		}

		public Address BusinessGetById(int id)
		{
			return _addressDal.GetById(id);
		}

		public void BusinessUpdate(Address entity)
		{
			_addressDal.Update(entity);
		}
	}
}
