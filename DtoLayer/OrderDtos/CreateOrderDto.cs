using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.OrderDtos
{
	public class CreateOrderDto
	{
		public int UserId { get; set; }
		public DateTime Date { get; set; }

	}
}
