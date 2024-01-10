using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entity
{
	public class Review
	{
        public int ReviewId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        [ForeignKey("AppUser")]
        public int UserId { get; set; }
        public AppUser AppUser { get; set; }
        public DateTime DateTime { get; set; }
        public int StarCount { get; set; }
        public bool HalfStarCount { get; set; }
        public string ReviewDetail { get; set; }
    }
}
