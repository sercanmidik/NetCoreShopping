using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Order
	{
        public int OrderId { get; set; }
    
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
		public DateTime Date { get; set; }
        public decimal TotalOrder { get; set; }
        public bool Status { get; set; }
        public bool PayPal { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
