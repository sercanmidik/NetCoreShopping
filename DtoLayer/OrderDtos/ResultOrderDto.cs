using EntityLayer.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.OrderDtos
{
	public class ResultOrderDto
	{
		public int OrderId { get; set; }
		public int UserId { get; set; }
		public DateTime Date { get; set; }
		public decimal TotalOrder { get; set; }
		public bool Status { get; set; }
	}
}
